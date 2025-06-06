﻿using POS.Forms.ItemRegistration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Misc
{
    public static class Departments_Store
    {
        static bool hasLoaded = false;
        public static BindingList<string> Departments { get; private set; } = new BindingList<string> { string.Empty };

        public static void AddNewDepartment(string newDepartment)
        {
            if (string.IsNullOrWhiteSpace(newDepartment))
                return;

            if (string.IsNullOrEmpty(newDepartment))
                return;

            if (Departments.Any(d => d.Equals(newDepartment, System.StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            Departments.Add(newDepartment);
        }

        public static async Task LoadDepartments_Async()
        {
            if (hasLoaded)
                return;

            try
            {
                using (var context = POSEntities.Create())
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
