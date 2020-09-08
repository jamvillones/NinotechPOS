using POS.Misc;
using POS.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class ConsoleSell : Form
    {
        public ConsoleSell()
        {
            InitializeComponent();
        }

        const int maxItemInView = 20;
        int currentIndex = 1;
        int max = 1;
        int currentItemCount = 1;

        List<ItemBoxHolder> items = new List<ItemBoxHolder>();

        private void ConsoleSell_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var it = p.InventoryItems.Where(x => x.Product.Item.Type == ItemType.Hardware.ToString()).OrderBy(y => y.Product.Item.Name);
                searchControl1.SetAutoComplete(it.Select(x => x.Product.Item.Name).ToArray());
                foreach (var i in it)
                {
                    var j = new UserControls.ItemBoxHolder();
                    j.ItemChosen += J_Click;
                    j.SetValues(i.Product.Item.SellingPrice, i.Quantity, Misc.ImageDatabaseConverter.byteArrayToImage(i.Product.Item.SampleImage), i.Product.Item.Barcode, i.SerialNumber, i.Product.Item.Name);
                    items.Add(j);
                }
                currentItemCount = items.Count;
                max = currentItemCount / maxItemInView;
                index.Text = currentIndex + "/" + (max + 1).ToString();

                itemsHolder.Controls.Clear();
                for (int i = 0; i < currentIndex * maxItemInView; i++)
                    itemsHolder.Controls.Add(items[i]);
            }
        }

        private void J_Click(object sender, EventArgs e)
        {
            ItemBoxHolder s = sender as ItemBoxHolder;
            MessageBox.Show(s.ItemName);
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (currentIndex == 1)
                return;
            currentIndex--;

            index.Text = currentIndex + "/" + (max + 1).ToString();

            itemsHolder.Controls.Clear();
            for (int i = (currentIndex * maxItemInView) - maxItemInView; i < currentIndex * maxItemInView; i++)
                itemsHolder.Controls.Add(items[i]);
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (currentIndex == max + 1)
                return;
            currentIndex++;

            index.Text = currentIndex + "/" + (max + 1).ToString();

            itemsHolder.Controls.Clear();
            int m = currentIndex * maxItemInView;
            for (int i = (currentIndex * maxItemInView) - maxItemInView; i < (m > currentItemCount ? currentItemCount : m); i++)
                itemsHolder.Controls.Add(items[i]);
        }

        private void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            var it = items.Where(x => x.Barcode == e.Text).ToArray();
            if (it.Length == 0)
            {
                it = items.Where(x => x.ItemName.ToLower().Contains(e.Text.ToLower())).ToArray();
                if (it.Length == 0)
                {
                    it = items.Where(x => x.Serial == e.Text).ToArray();
                }
            }
            if (it.Length == 0)
            {
                MessageBox.Show("No items found.");
                return;
            }

            e.SearchFound = true;
            currentIndex = 1;
            currentItemCount = it.Length;
            max = currentItemCount / maxItemInView;
            index.Text = currentIndex + "/" + (max + 1).ToString();
            int m = currentIndex * maxItemInView;
            itemsHolder.Controls.Clear();

            for (int i = (currentIndex * maxItemInView) - maxItemInView; i < (m > currentItemCount ? currentItemCount : m); i++)
                itemsHolder.Controls.Add(it[i]);
        }

        private void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            currentItemCount = items.Count;
            max = currentItemCount / maxItemInView;

            index.Text = currentIndex + "/" + (max + 1).ToString();

            int m = currentIndex * maxItemInView;

            itemsHolder.Controls.Clear();
            for (int i = 0; i < (m > currentItemCount ? currentItemCount : m); i++)
                itemsHolder.Controls.Add(items[i]);
        }
    }
}
