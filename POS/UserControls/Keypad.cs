using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UserControls
{
    public partial class Keypad : UserControl
    {
        //TextBox target;
        //public event EventHandler UpButton;
        //public event EventHandler DownButton;
        public Keypad()
        {
            InitializeComponent();
        }

        //public void SetTarget(TextBox t)
        //{
        //    target = t;
        //}
        void buttonPressed(string s)
        {
            //if (target == null)
            //    return;
            //if (target.TextLength == target.MaxLength)
            //    return;
            SendKeys.Send("{" + s + "}");
        }
        private void seven_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("7");
        }

        private void eight_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("8");
        }

        private void nine_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("9");
        }

        private void four_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("4");
        }

        private void five_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("5");
        }

        private void six_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("6");
        }

        private void one_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("1");
        }

        private void two_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("2");
        }

        private void three_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("3");
        }

        private void backspace_Click(object sender, MouseEventArgs e)
        {
            //if (target == null)
            //    return;
            //if (string.IsNullOrEmpty(target.Text))
            //    return;
            //target.Text = target.Text.Remove(target.Text.Length - 1);
            buttonPressed("BACKSPACE");
        }

        private void zero_Click(object sender, MouseEventArgs e)
        {
            buttonPressed("0");
        }

        private void period_Click(object sender, MouseEventArgs e)
        {           
            buttonPressed(".");
        }

        //private void clearBtn_Click(object sender, EventArgs e)
        //{
        //    //if (target is TextBox)
        //    //{
        //    //    var t = (TextBox)target;
        //    //    t.Clear();


        //    //}
        //}
    }
}
