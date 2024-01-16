using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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

        public static void DecimalOnlyEditting(this DataGridView table, int columIndex)
        {
            table.EditingControlShowing += (sender, e) =>
            {

                var dgtTable = sender as DataGridView;
                if (e.Control is TextBox t)
                {
                    t.Validating += T_Validating;
                    t.TextChanged += T_TextChanged;
                    t.Text = dgtTable[columIndex, dgtTable.SelectedCells[0].RowIndex].Value.ToString();
                }
            };
        }

        public static void DecimalOnlyEditting(this DataGridView table, Action<TextBox> SetAction)
        {
            table.EditingControlShowing += (sender, e) =>
            {

                var dgtTable = sender as DataGridView;
                if (e.Control is TextBox t)
                {
                    t.Validating += T_Validating;
                    t.TextChanged += T_TextChanged;

                    SetAction(t);
                    //t.Text = dgtTable[columIndex, dgtTable.SelectedCells[0].RowIndex].Value.ToString();
                }
            };
        }

        public static void Table_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var table = sender as DataGridView;
            if (e.Control is TextBox t)
            {
                t.Validating += T_Validating;
                t.TextChanged += T_TextChanged;
                t.Text = table[table.SelectedCells[0].ColumnIndex, table.SelectedCells[0].RowIndex].Value.ToString();
            }
        }
        /// <summary>
        /// handles the case where the textbox is empty and must have a default value of 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void T_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox t)
            {
                if (string.IsNullOrWhiteSpace(t.Text))
                {
                    t.Text = "0.00";
                }
            }
        }
        /// <summary>
        /// handles the character input which ensures numbers and a single period (.) only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void T_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            textbox.KeyPress += (s, args) =>
            {
                if (s is TextBox t)
                {
                    //if (string.IsNullOrWhiteSpace(t.Text)) {
                    //    t.Text = "0";
                    //    args.Handled = false;
                    //    return;
                    //}
                    if (!char.IsControl(args.KeyChar) && !char.IsDigit(args.KeyChar) && (args.KeyChar != '.'))
                    {
                        args.Handled = true;
                    }
                    // only allow one decimal point
                    if ((args.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    {
                        args.Handled = true;
                    }
                }
            };
        }

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
