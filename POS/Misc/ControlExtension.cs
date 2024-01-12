using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public static class ControlExtension
    {
        public static DataGridViewRow CreateRow(this DataGridView dt, params object[] obs)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dt, obs);
            return row;
        }

        //public static DataGridViewRow CreateRow<T>(this T entity, DataGridView source, Action<T> Configure)
        //{
        //    var row = new DataGridViewRow();

        //    row.CreateCells(,)

        //    return row;
        //}

        public static void InvokeIfRequired(this Control c, Action a)
        {
            try
            {
                if (c.InvokeRequired)
                    c?.Invoke(a);
                else
                    a();
            }
            catch
            {

            }
        }
    }
}
