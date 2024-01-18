using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using VS2017POS.EntitiyFolder;

namespace POS.Misc {
    public static class Helper {
        public static string EmptyIfNull(this string s) {
            return string.IsNullOrWhiteSpace(s) ? null : s.Trim();
        }


        public static List<T> GetContainedControls<T>(this Control control) where T : Control {
            List<T> temp = new List<T>();
            foreach (var i in control.Controls) {
                if (i is T)
                    temp.Add((T)i);

                else
                    foreach (var j in GetContainedControls<T>(i as Control))
                        temp.Add(j);
            }
            return temp;
        }

        public static void TextBoxTrimSpaces(object sender, EventArgs e) {
            TextBox t = (TextBox)sender;

            if (string.IsNullOrEmpty(t.Text))
                return;
            if (t.Multiline)
                return;
            t.Text = t.Text.Trim(' ');
        }

        public static Item ItemByIndex(DataGridView dataGridView) {
            var item = new Item();
            int index = dataGridView.SelectedCells[0].RowIndex;
            var selectedRow = dataGridView.Rows[index];
            string Value = Convert.ToString(selectedRow.Cells[0].Value);
            using (var p = new POSEntities()) {
                item = p.Items.FirstOrDefault(x => x.Id == Value);
            }
            return item;
        }

        public static Supplier getSupplier(this Control control) {
            using (var p = new POSEntities()) {
                return p.Suppliers.FirstOrDefault(x => x.Name == control.Text);
            }
        }
        public static Item getItemByIndex(this DataGridView dgt) {
            Item item;
            string barcode = dgt.Rows[dgt.CurrentCell.RowIndex].Cells["Barcode"].Value.ToString();
            using (var p = new POSEntities()) {
                item = p.Items.FirstOrDefault(x => x.Id == barcode);
                return item;
            }
        }

        public static void OpenForm<T>(this UserControl source, T form) where T : Form, new() {
            if (form == null) {
                source.Enabled = false;
                form = new T();
                form.FormClosing += (a, b) => {
                    source.Enabled = true;
                    form = null;
                };
                form.Show();
            }
        }

        public static int DataGridViewCurrentRowIndex(this DataGridView dgt) {
            if (dgt.SelectedCells.Count == 0)
                return -1;
            return dgt.SelectedCells[0].RowIndex;
        }

        public static int GetSelectedId(this DataGridView dgt) {
            if (dgt.RowCount == 0)
                return -1;

            return (int)(dgt.Rows[dgt.DataGridViewCurrentRowIndex()].Cells[0].Value);
        }
        public static int LongestWord(Graphics g, Font f, int width, params string[] words) {
            return (int)words.Select(x => g.MeasureString(x, f, width).Height).DefaultIfEmpty(0).Max();
        }


        public static string ToCurrency(this decimal d) => d.ToString("C2");
        //public static string ToCurrency(this decimal money) {
        //    return string.Format("₱{0:N2}", money);
        //}
    }
}
