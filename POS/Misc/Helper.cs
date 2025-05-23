﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using VS2017POS.EntitiyFolder;

namespace POS.Misc
{
    public static class Helper
    {
        /// <summary>
        /// returns null if the text is empty, null, or whitespace. resulting string is trimmed of whitespace 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string NullIfEmpty(this string s) => string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s) || s.Equals("n/a", StringComparison.OrdinalIgnoreCase) ? null : s.Trim();

        public static decimal Clamp(this decimal value, decimal min, decimal max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static string Base36Encode(this string hex)
        {
            long value = Convert.ToInt64(hex, 16);
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            while (value > 0)
            {
                result = chars[(int)(value % 36)] + result;
                value /= 36;
            }
            return result.PadLeft(12, '0');
        }

        public static bool IsEmpty(this string s) => string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s);

        public static List<T> GetContainedControls<T>(this Control control) where T : Control
        {
            List<T> temp = new List<T>();
            foreach (var i in control.Controls)
            {
                if (i is T)
                    temp.Add((T)i);

                else
                    foreach (var j in GetContainedControls<T>(i as Control))
                        temp.Add(j);
            }
            return temp;
        }

        public static void TextBoxTrimSpaces(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (string.IsNullOrEmpty(t.Text))
                return;
            if (t.Multiline)
                return;
            t.Text = t.Text.Trim(' ');
        }

        public static Item ItemByIndex(DataGridView dataGridView)
        {
            var item = new Item();
            int index = dataGridView.SelectedCells[0].RowIndex;
            var selectedRow = dataGridView.Rows[index];
            string Value = Convert.ToString(selectedRow.Cells[0].Value);
            using (var p = POSEntities.Create())
            {
                item = p.Items.FirstOrDefault(x => x.Id == Value);
            }
            return item;
        }

        public static Supplier getSupplier(this Control control)
        {
            using (var p = POSEntities.Create())
            {
                return p.Suppliers.FirstOrDefault(x => x.Name == control.Text);
            }
        }
        public static Item getItemByIndex(this DataGridView dgt)
        {
            Item item;
            string barcode = dgt.Rows[dgt.CurrentCell.RowIndex].Cells["Barcode"].Value.ToString();
            using (var p = POSEntities.Create())
            {
                item = p.Items.FirstOrDefault(x => x.Id == barcode);
                return item;
            }
        }

        public static void OpenForm<T>(this UserControl source, T form) where T : Form, new()
        {
            if (form == null)
            {
                source.Enabled = false;
                form = new T();
                form.FormClosing += (a, b) =>
                {
                    source.Enabled = true;
                    form = null;
                };
                form.Show();
            }
        }

        public static int DataGridViewCurrentRowIndex(this DataGridView dgt)
        {
            if (dgt.SelectedCells.Count == 0)
                return -1;
            return dgt.SelectedCells[0].RowIndex;
        }

        public static int GetSelectedId(this DataGridView dgt)
        {
            if (dgt.RowCount == 0)
                return -1;

            return (int)(dgt.Rows[dgt.DataGridViewCurrentRowIndex()].Cells[0].Value);
        }
        public static int LongestWord(Graphics g, Font f, int width, params string[] words)
        {
            return (int)words.Select(x => g.MeasureString(x, f, width).Height).DefaultIfEmpty(0).Max();
        }


        public static string ToCurrency(this decimal d) => d.ToString("C2");
        //public static string ToCurrency(this decimal money) {
        //    return string.Format("₱{0:N2}", money);
        //}
    }
}
