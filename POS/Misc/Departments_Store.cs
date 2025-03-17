using POS.Forms.ItemRegistration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POS.Misc
{
    public static class Departments_Store
    {
        static bool hasLoaded = false;
        public static BindingList<string> Departments { get; private set; } = new BindingList<string> { "" };

        public static async Task LoadDepartments_Async()
        {
            if (hasLoaded)
                return;

            try
            {
                using (var context = new POSEntities())
                {
                    var departments = await context.Items
                        .AsNoTracking()
                        .GetDepartments()
                        .ToListAsync();

                    foreach (var department in departments)
                        Departments.Add(department);
                }
            }
            catch (System.Exception)
            {

            }

            hasLoaded = true;
        }
    }
}
