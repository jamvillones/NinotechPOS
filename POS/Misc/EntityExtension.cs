using Connections;
using OfficeOpenXml;
using POS.Forms;
using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public static class WarrantyChecker
    {
        /// <summary>
        /// Determines if the product is still under warranty.
        /// </summary>
        /// <param name="purchaseDate">The date the product was purchased.</param>
        /// <param name="warrantyDays">The warranty period in days.</param>
        /// <returns>True if the product is under warranty, otherwise false.</returns>
        public static bool IsUnderWarranty(this DateTime purchaseDate, int warrantyDays)
        {
            DateTime warrantyEndDate = purchaseDate.AddDays(warrantyDays);
            return DateTime.Now <= warrantyEndDate;
        }

        public static int DaysLeftOfWarranty(this DateTime purchaseDate, int warrantyDays)
        {
            DateTime warrantyEndDate = purchaseDate.AddDays(warrantyDays);
            TimeSpan difference = warrantyEndDate - DateTime.Now;
            return (int)Math.Ceiling(difference.TotalDays);
        }

        public static string ToDaysToYMWD(this int totalDays)
        {
            int years = totalDays / 365;
            int remainingDays = totalDays % 365;

            int months = remainingDays / 30;
            remainingDays %= 30;

            int weeks = remainingDays / 7;
            int days = remainingDays % 7;

            // Build the result string dynamically
            List<string> parts = new List<string>();
            if (years > 0)
                parts.Add($"{years} year{(years > 1 ? "s" : "")}");
            if (months > 0)
                parts.Add($"{months} month{(months > 1 ? "s" : "")}");
            if (weeks > 0)
                parts.Add($"{weeks} week{(weeks > 1 ? "s" : "")}");
            if (days > 0 || parts.Count == 0) // Always show days if all are zero
                parts.Add($"{days} day{(days > 1 ? "s" : "")}");

            return string.Join(", ", parts);
        }

    }

    partial class Item : BaseModel
    {
        public int QuantityInInventory => this.Products
            .Select(a => a.InventoryItems.Where(x => !x.IsDefective)
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

    partial class SoldItem
    {
        public string WarrantyStatus => Product.Item.Warranty == 0 ? "--" : (DateAdded.IsUnderWarranty((int)Product.Item.Warranty) ? $"Active ({DateAdded.DaysLeftOfWarranty((int)Product.Item.Warranty)})" : "Expired");

    }
    public partial class ChargedPayRecord
    {
        public override string ToString() => $"{TransactionTime?.ToString("MMM d yyyy - h:mm tt")} - {AmountPayed?.ToString("C")}";
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
        public string AdditionalDetails { get; set; } = "";

        public override async Task<int> SaveChangesAsync()
        {
            int changesMade = 0;
            try
            {
                this.LogChanges(UserManager.instance.CurrentLogin, AdditionalDetails);

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

    public readonly struct ExcelData
    {
        public ExcelData(string Barcode, string Name, string Supplier, string SerialNumber, int Quantity)
        {
            this.Barcode = Barcode;
            this.Name = Name;
            this.Supplier = Supplier;
            this.SerialNumber = SerialNumber;
            this.Quantity = Quantity;
        }
        public string Barcode { get; }
        public string Name { get; }
        public string Supplier { get; }
        public string SerialNumber { get; }
        public int Quantity { get; }
    }

    public static class DataTableHelper
    {
        public static DataTable ToDataTable<T>(this List<T> items, params string[] selectedProperties)
        {
            DataTable table = new DataTable(typeof(T).Name);
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var filteredProps = selectedProperties.Length > 0 ? properties.Where(p => selectedProperties.Any(x => x.Equals(p.Name))).ToArray() : properties.ToArray();

            // Add columns
            foreach (var prop in filteredProps)
            {
                string formattedName = InsertSpacesInCamelCase(prop.Name);
                table.Columns.Add(formattedName.ToUpper(), Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Add rows
            foreach (var item in items)
            {
                var values = new object[filteredProps.Length];

                for (int i = 0; i < filteredProps.Length; i++)
                    values[i] = filteredProps[i].GetValue(item, null);

                table.Rows.Add(values);
            }

            return table;
        }

        private static string InsertSpacesInCamelCase(string input)
        {
            return Regex.Replace(input, "(?<!^)([A-Z])", " $1");
        }
    }

    public static class ContextManipulationMethods
    {
        public static IQueryable<InventoryItem> FilterItems(this IQueryable<InventoryItem> inventoryItems, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return inventoryItems;
            }

            return inventoryItems.Where(
                x => x.SerialNumber.Contains(keyword) || 
                x.Product.Item.Name.Contains(keyword) || 
                x.Product.Supplier.Name.Contains(keyword));
        }

        public static IQueryable<SoldItem> FilterItems(this IQueryable<SoldItem> inventoryItems, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return inventoryItems;
            }

            return inventoryItems.Where(
                x => x.SerialNumber.Contains(keyword) ||
                x.Product.Item.Name.Contains(keyword) ||
                x.Product.Supplier.Name.Contains(keyword));
        }

        public static IQueryable<InventoryItem> IsValid(this IQueryable<InventoryItem> inv) => inv.Where(x => !x.IsDefective);
        public static IQueryable<SoldItem> IsValid(this IQueryable<SoldItem> soldItems) => soldItems.Where(x => !x.IsDefective);

        public static void LogChanges(this POSEntities context, Login user, string details = "")
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
                            strBuilder.AppendLine($"Property '{property}': '{originalValue}'→'{currentValue}'");
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

            context.ChangeLogs.Add(new ChangeLog()
            {
                MadeBy = user?.ToString() ?? "admin",
                Details = strBuilder.ToString() + (string.IsNullOrEmpty(details) ? string.Empty : "\n *NOTE:" + details)
            });
        }
        public static bool HasChanges(this DbContext context) => context.ChangeTracker.Entries().Any(e => e.IsEntityActuallyModified());
        public static bool IsEntityActuallyModified(this DbEntityEntry entry)
        {
            if (entry.State == EntityState.Modified)
            {
                foreach (var propName in entry.OriginalValues.PropertyNames)
                {
                    var original = entry.OriginalValues[propName];
                    var current = entry.CurrentValues[propName];

                    if (!object.Equals(original, current))
                        return true;
                }
            }

            return entry.State == EntityState.Added || entry.State == EntityState.Deleted;
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
        public static async Task<bool> ExtractInventory(string department = "")
        {
            try
            {
                using (var context = POSEntities.Create())
                {
                    var entries = await context.InventoryItems
                                .AsNoTracking()
                                .AsQueryable()
                                .Where(inv => inv.Product.Item.Type == ItemType.Quantifiable.ToString())
                                .FilterByDepartment(department)
                                .OrderBy(x => x.Product.Item.Name)
                                .ToListAsync();

                    var data = entries.ProcessInventoryData();

                    var dataTable = data.ToDataTable();

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = $"Inventory Export {(string.IsNullOrEmpty(department) ? "" : "[" + department.ToUpper() + "] ")}{DateTime.Now:MMddyyyyHHmmss}.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (var package = new ExcelPackage())
                            {
                                var worksheet = package.Workbook.Worksheets.Add("Data");
                                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                                for (int col = 1; col <= dataTable.Columns.Count; col++)
                                {
                                    var colType = dataTable.Columns[col - 1].DataType;
                                    if (colType == typeof(DateTime))
                                        worksheet.Column(col).Style.Numberformat.Format = "MMM d yyyy - h:mm";
                                }
                                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                                worksheet.Cells[worksheet.Dimension.Address].Style.WrapText = true;

                                await package.SaveAsAsync(new FileInfo(saveFileDialog.FileName));

                                if (MessageBox.Show("Export successful!\nDo you want to open the file?", "Export Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return true;
                            }
                        }

                        await Task.Delay(2000);

                        var dir = Path.GetDirectoryName(saveFileDialog.FileName);

                        Console.WriteLine("dir->" + dir + "\"" + saveFileDialog.FileName);

                        string fileName = @saveFileDialog.FileName;
                        Process.Start("Excel.exe", $"\"{fileName}\"");
                    }
                }
            }
            catch (Exception)
            { }

            return true;
        }
        public static List<ExcelData> ProcessInventoryData(this List<InventoryItem> inventoryItems)
        {
            var NameGroup = inventoryItems.GroupBy(i => i.Product.Item.Name);
            var list = new List<ExcelData>();

            foreach (var name in NameGroup)
            {
                var groupedByName = inventoryItems.Where(i => i.Product.Item.Name == name.Key);

                var productGroup = groupedByName.GroupBy(x => x.ProductId);

                foreach (var product in productGroup)
                {
                    var prod = inventoryItems.FirstOrDefault(i => i.ProductId == product.Key)?.Product;

                    var serialNumber = !prod.Item.IsSerialRequired ? string.Empty :
                        string.Join(Environment.NewLine, inventoryItems.Where(i => i.ProductId == product.Key).Select(a => "▸" + a.SerialNumber));

                    var qty = inventoryItems.Where(i => i.ProductId == product.Key).Select(a => a.Quantity).Sum();

                    list.Add(new ExcelData(
                        prod.Item.Barcode,
                        prod.Item.Name,
                        prod.Supplier.Name,
                        serialNumber,
                        qty
                        ));
                }
            }
            return list;
        }
    }

}

