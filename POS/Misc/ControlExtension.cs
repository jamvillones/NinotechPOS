using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public static class ControlExtension
    {
        public static string GetVersion(this Control control) => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static Form EmbedForm(this Control control, Form frm)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Dock = DockStyle.Fill;   // optional
            frm.BringToFront();
            control.Controls.Add(frm);
            return frm;
        }

        public static DialogResult ShowLoginUnauthorizedMessage(this Control control) =>
             MessageBox.Show("Your permission has been revoked! Contact ADMINISTRATOR for more details. ", "Operation Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static DataGridViewRow CreateRow(this DataGridView dt, params object[] obs)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dt, obs);
            return row;
        }
        /// <summary>
        /// Get the ids in DataGridView assuming the Column Id is in 0th index. selected rows is outed so that it can be manually removed
        /// </summary>
        /// <typeparam name="T">T is either int or string</typeparam>
        /// <param name="table"></param>
        /// <param name="selectedRows"></param>
        /// <returns>Returns The Id used for tacking entities</returns>
        public static IEnumerable<T> GetSelectedIds<T>(this DataGridView table, out IEnumerable<DataGridViewRow> selectedRows, int columnIndex = 0)
        {
            selectedRows = table.SelectedRows.Cast<DataGridViewRow>();
            return selectedRows.Select(x => (T)x.Cells[columnIndex].Value);
        }

        public static bool ComputeExpression(this TextBox textbox, decimal min = 0, decimal max = 999999999)
        {
            string text = textbox.Text.Trim();

            if (text.IsEmpty())
            {
                textbox.Text = "0.00";
                return false;
            }
            if (decimal.TryParse(text, out decimal newPrice))
            {
                textbox.Text = newPrice.Clamp(min, max).ToString("F2");
                return false;
            }

            try
            {
                var result = new DataTable().Compute(text, null);
                if (decimal.TryParse(result.ToString(), out decimal computedPrice))
                    textbox.Text = computedPrice.Clamp(min, max).ToString("F2");
            }
            catch
            {
                MessageBox.Show("Expression cannot be parsed!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Undo();
                textbox.ClearUndo();
                return true;
            }
            return false;
        }

        public static void DecimalOnlyEditting(this DataGridView table, int columnIndex)
        {

            table.EditingControlShowing += (sender, e) =>
            {
                var dgtTable = sender as DataGridView;

                if (table.CurrentCell.ColumnIndex != columnIndex)
                    return;

                if (e.Control is TextBox t)
                {
                    t.Validating += T_Validating;
                    t.TextChanged += T_TextChanged;
                    t.Text = dgtTable[columnIndex, dgtTable.SelectedCells[0].RowIndex].Value.ToString();
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


        public static List<T> GetControls<T>(this Control parent) where T : Control
        {
            var controls = new List<T>();

            foreach (Control c in parent.Controls)
            {
                if (c is T a)
                    controls.Add(a);
                else
                    controls.AddRange(c.GetControls<T>());
            }

            return controls;
        }

        public static List<Control> GetControls(this Control parent, Func<Control, bool> Condition)
        {
            var controls = new List<Control>();

            foreach (Control c in parent.Controls)
            {
                if (Condition(c))
                    controls.Add(c);
                else
                    controls.AddRange(c.GetControls(Condition));
            }

            return controls;
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
