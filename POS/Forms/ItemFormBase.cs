using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Misc;

namespace POS.Forms
{
    public partial class ItemFormBase : Form
    {
        public event EventHandler OnSave;
        protected void InvokeEvent()
        {
            OnSave?.Invoke(this, new EventArgs());
        }

        public ItemFormBase()
        {
            InitializeComponent();

        }
        protected virtual void clearFields()
        {
            ImageBox.Image = null;
            var texts = this.GetContainedControls<TextBox>();
            foreach (var t in texts)
                t.Clear();
            var combos = this.GetContainedControls<ComboBox>();
            //foreach (var c in combos)
            //    c.ResetText();
            var nums = this.GetContainedControls<NumericUpDown>();
            foreach (var n in nums)
                n.Value = 0;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            save();
        }
        private void AddItemForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        public virtual bool canSave()
        {
            return true;
        }

        public virtual void save()
        {
        }

        public virtual void Init()
        {
            try
            {
                using (var p = new POSEntities())
                {
                    itemDepartment.Items.Clear();
                    itemDepartment.AutoCompleteCustomSource.Clear();
                    var itemDeptGroup = p.Items.GroupBy(x => x.Department);

                    foreach (var i in itemDeptGroup)
                    {
                        //Console.WriteLine("add");
                        if (i.Key != null)
                        {
                            itemDepartment.Items.Add(i.Key);
                            itemDepartment.AutoCompleteCustomSource.Add(i.Key);
                        }
                    }

                }
                var textboxes = this.GetContainedControls<TextBox>();
                foreach (var i in textboxes)
                {
                    i.Leave += Helper.TextBoxTrimSpaces;
                }
            }
            catch
            {

            }
        }

        private void takePhotoBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;*.png)|*.jpg; *.jpeg; *.gif; *.bmp;*.png";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    ImageBox.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
