using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public static class ControlExtension
    {
        public static DataGridViewRow createRow(this DataGridView dt, params object[] obs)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dt, obs);
            return row;
        }
    }
}
