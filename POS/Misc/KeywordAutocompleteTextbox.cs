﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace test
{
    public class KeywordAutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private string _formerValue = string.Empty;

        public KeywordAutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();

            this.KeyDown += this_KeyDown;
            this.KeyUp += this_KeyUp;
        }

        private void InitializeComponent()
        {
            this._listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _listBox
            // 
            this._listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._listBox.Location = new System.Drawing.Point(0, 0);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(120, 96);
            this._listBox.TabIndex = 0;
            // 
            // KeywordAutoCompleteTextBox
            // 
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeywordAutoCompleteTextBox_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Form parentForm = this.FindForm(); // new line added
                parentForm.Controls.Add(_listBox); // adds it to the form
                _listBox.KeyDown += ParentForm_KeyDown;
                _listBox.MouseClick += _listBox_MouseClick;
                Point positionOnForm = parentForm.PointToClient(this.Parent.PointToScreen(this.Location)); // absolute position in the form
                _listBox.Left = positionOnForm.X;
                _listBox.Top = positionOnForm.Y + Height;
                _isAdded = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
        }

        private void _listBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_listBox.Visible)
            {
                Text = _listBox.SelectedItem.ToString();
                ResetListBox();
                _formerValue = Text;
                this.Select(this.Text.Length, 0);
                // e.Handled = true;
            }
        }

        private void ParentForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {
                            Text = _listBox.SelectedItem.ToString();
                            ResetListBox();
                            _formerValue = Text;
                            this.Select(this.Text.Length, 0);
                            e.Handled = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;
                        e.Handled = true;
                        break;
                    }
            }
        }

        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (_listBox.Visible)
                {
                    Text = _listBox.SelectedItem.ToString();
                    ResetListBox();
                    _formerValue = Text;
                    this.Select(this.Text.Length, 0);
                    e.Handled = true;
                }
                return;
            }
            UpdateListBox();
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //case Keys.Enter:
                //case Keys.Tab: {

                //        break;
                //    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;
                        e.Handled = true;
                        break;
                    }
                case Keys.Escape:
                    ResetListBox();
                    break;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _listBox.Visible)
            {
                Text = _listBox.SelectedItem.ToString();
                ResetListBox();
                _formerValue = Text;
                this.Select(this.Text.Length, 0);

                e.Handled = true;
            }
            else
                base.OnKeyDown(e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    return _listBox.Visible;
                default:
                    return base.IsInputKey(keyData);
            }
        }


        bool EntryMatched(string entry, string word)
        {
            if (entry is null)
                return false;

            //return entry.Contains(word);
            return entry.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void UpdateListBox()
        {
            if (Text == _formerValue)
                return;

            _formerValue = this.Text;
            string word = this.Text;

            if (Values != null && word.Length > 0)
            {
                string[] matches = Array.FindAll(Values, x => EntryMatched(x, word));
                if (matches.Length > 0)
                {
                    ShowListBox();
                    _listBox.BeginUpdate();
                    _listBox.Items.Clear();
                    _listBox.Font = this.Font;
                    Array.ForEach(matches, x => _listBox.Items.Add(x));
                    _listBox.SelectedIndex = 0;
                    _listBox.Height = 0;
                    _listBox.Width = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            if (i < 20)
                                _listBox.Height += _listBox.GetItemHeight(i);
                            // it item width is larger than the current one
                            // set it to the new max item width
                            // GetItemRectangle does not work for me
                            // we add a little extra space by using '_'
                            //int itemWidth = (int)graphics.MeasureString(((string)_listBox.Items[i]) + "_", _listBox.Font).Width;
                            //_listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : this.Width; ;
                            _listBox.Width = this.Width;
                        }
                    }
                    _listBox.EndUpdate();
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }

        public string[] Values { get; set; }

        public List<string> SelectedValues
        {
            get
            {
                string[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new List<string>(result);
            }
        }

        private void KeywordAutoCompleteTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
