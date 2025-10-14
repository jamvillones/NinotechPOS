using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class ReasonForReturnForm : Form
    {
        public ReasonForReturnForm()
        {
            InitializeComponent();
        }

        private static readonly HashSet<string> InvalidReasons = new HashSet<string>    {
        "-", "n/a", "na", "none", ".", "n.a.", ""    };

        public static bool IsValidReason(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string reason = input.Trim().ToLower();

            // 1. Check against banned list
            if (InvalidReasons.Contains(reason))
                return false;

            // 2. Enforce minimum length (e.g., at least 5 characters)
            if (reason.Length < 5)
                return false;

            // 3. Ensure it contains at least one letter or number
            if (!Regex.IsMatch(reason, @"[a-zA-Z0-9]"))
                return false;

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reason = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Please provide a reason for this action", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsValidReason(reason.ToLower()))
            {
                MessageBox.Show("Please provide an useful information for this action!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.SelectAll();
                textBox1.Focus();
                return;
            }


            Tag = reason;
            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
