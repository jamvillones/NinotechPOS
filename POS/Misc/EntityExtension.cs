using Connections;
using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using POS.Forms;
using System.Text;

namespace POS
{
    partial class Item : BaseModel
    {
        public int QuantityInInventory => this.Products
            .Select(a => a.InventoryItems
                .Select(b => b.Quantity)
                .DefaultIfEmpty(0)
                .Sum())
            .Sum();

        public bool InCriticalQuantity
        {
            get
            {
                if (!IsEnumerable || this.CriticalQuantity == null) return false;

                var totalQty = this.QuantityInInventory;

                if (totalQty == 0)
                    return false;

                return (totalQty <= this.CriticalQuantity);
            }
        }

        public bool IsEnumerable =>
            this.Type == ItemType.Quantifiable.ToString();

        public override string ToString() => $"{Name}-{Id}";
    }

    public partial class POSEntities
    {
        public static POSEntities Create()
        {
            var context = new POSEntities();
            context.ChangeDatabase();

            if (UserManager.instance.CurrentLogin != null)
            {
                //verify the login credentials
                var loginId = UserManager.instance.CurrentLogin.Id;
                var login = context.Logins.FirstOrDefault(x => x.Id == loginId);

                if (!login.CanEditProduct)
                    throw new UnautorizedLoginException();

            }

            return context;
        }
    }

    public partial class Product
    {
        public override string ToString() => $"{Item.Name} - {Supplier?.Name ?? "*No Supplier"}";

        //public Product Self => this;
    }

    partial class Sale
    {
        /// <summary>
        /// grand total of the sale
        /// </summary>
        public decimal AmountDue => Total - Discount;
        public decimal Total => SoldItems.Sum(x => x.Quantity * (x.ItemPrice - x.Discount));

        /// <summary>
        /// used as the actual gained money
        /// </summary>
        public decimal TotalGained => AmountRecieved > AmountDue ? AmountDue : AmountRecieved;
        /// <summary>
        /// remaining to be paid
        /// </summary>
        public decimal Remaining => (AmountDue - AmountRecieved) < 0 ? 0 : AmountDue - AmountRecieved;
        /// <summary>
        /// is it fully paid?
        /// </summary>
        public bool FullyPaid => Remaining == 0;
    }

    partial class Supplier
    {
        public override string ToString() => Name + (string.IsNullOrWhiteSpace(ContactDetails) ? "" : " - " + ContactDetails);

        public Supplier Self => this;
    }

    partial class Customer
    {
        public override string ToString() => Name +
            (string.IsNullOrWhiteSpace(ContactDetails) ? "" : " - " + ContactDetails) +
            (string.IsNullOrWhiteSpace(Address) ? "" : " - " + Address);
    }

    partial class Login
    {
        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? Username : Name;
    }


    public class BaseModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public string this[string propertyName]
        {
            get
            {
                var descriptor = TypeDescriptor.GetProperties(this)[propertyName];
                if (descriptor is null)
                    return string.Empty;

                var errs = new List<ValidationResult>();
                var valContext = new ValidationContext(this, null, null) { MemberName = propertyName };

                if (!Validator.TryValidateProperty(descriptor?.GetValue(this), valContext, errs))
                    return errs.FirstOrDefault()?.ErrorMessage ?? string.Empty;

                return string.Empty;
            }
        }

        public string Error
        {
            get
            {
                var errs = new List<ValidationResult>();
                var valContext = new ValidationContext(this, null, null);

                if (!Validator.TryValidateObject(this, valContext, errs, true))
                    return string.Join(Environment.NewLine, errs);

                return string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    partial class POSEntities
    {
        public override async Task<int> SaveChangesAsync()
        {
            int changesMade = 0;
            try
            {
                this.LogChanges(UserManager.instance.CurrentLogin);

                changesMade = await base.SaveChangesAsync();
                return changesMade;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (changesMade > 0)
                {
                    this.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, @"EXEC [dbo].[sp_backup]");
                }
            }
        }
    }

    public static class ContextManipulationMethods
    {
        public static void LogChanges(this POSEntities context, Login user)
        {
            var entries = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            if (entries.Count() == 0) return;

            var strBuilder = new StringBuilder();

            foreach (var entry in entries)
            {
                string entityName = entry.Entity.GetType().Name;
                string state = entry.State.ToString();

                strBuilder.AppendLine($"▸ Entry: {entityName}, State: {state}");

                if (entry.State == EntityState.Added)
                {
                    strBuilder.AppendLine($"Values: {string.Join(" , ", entry.CurrentValues.PropertyNames.Where(prop => entry.CurrentValues[prop] != null).Select(prop => $"{prop}:{entry.CurrentValues[prop]}"))}");
                }
                else if (entry.State == EntityState.Modified)
                {
                    foreach (var property in entry.OriginalValues.PropertyNames)
                    {
                        var originalValue = entry.OriginalValues[property];
                        var currentValue = entry.CurrentValues[property];
                        if (!object.Equals(originalValue, currentValue))
                        {
                            // Log the change in the property value
                            strBuilder.AppendLine($"Property '{property}': '{originalValue}'->'{currentValue}'");
                        }
                    }
                }
                else if (entry.State == EntityState.Deleted)
                {
                    foreach (var property in entry.OriginalValues.PropertyNames)
                    {
                        var originalValue = entry.OriginalValues[property];
                        strBuilder.AppendLine($"Deleted: {property} = {originalValue}");
                    }
                }
            }

            context.ChangeLogs.Add(new ChangeLog() {  MadeBy = user.ToString(), Details = strBuilder.ToString() });
        }

        /// <summary>
        /// run this to set the isSerialRequired Property based on stockin entries with serial
        /// </summary>
        //public static void SetIsSerialRequired()
        //{
        //    using (var context = POSEntities.Create())
        //    {
        //        var items = context.Items.AsQueryable().Where(i => i.Products.Any(p => p.StockinHistories.Any(st => st.SerialNumber != null))).ToList();

        //        foreach (var i in items)
        //            i.IsSerialRequired = true;

        //        context.SaveChanges();
        //    }
        //}

        public static bool HasChanges(this DbContext context) => context.ChangeTracker.Entries().Any(e => e.IsEntityActuallyModified());


        public static bool IsEntityActuallyModified(this DbEntityEntry entry)
        {
            if (entry.State != EntityState.Modified)
                return false;

            foreach (var propName in entry.OriginalValues.PropertyNames)
            {
                var original = entry.OriginalValues[propName];
                var current = entry.CurrentValues[propName];

                if (!object.Equals(original, current))
                    return true;
            }

            return false;
        }

        public static void UndoAllChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        // Reset property values to original
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        // Remove newly added entities
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        // Revert deletion
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}

