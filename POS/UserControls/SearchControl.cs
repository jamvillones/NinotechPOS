using POS.Misc;
using System;
using System.Windows.Forms;

namespace POS.UserControls
{
    public partial class SearchControl : UserControl
    {
        public Control firstControl
        {
            get
            {
                return searchText;
            }
        }

        private string prevSearch = "";
        public bool SearchDone = false;
        /// <summary>
        /// triggers upon hitting enter or pressing search Button;
        /// </summary>
        public event EventHandler<SearchEventArgs> OnSearch;
        /// <summary>
        /// triggers when search bar text become empty and a search has been done
        /// </summary>
        public event EventHandler OnTextEmpty;
        public string SearchedText
        {
            get
            {
                return searchText.Text.Trim();
            }
            set
            {
                searchText.Text = value;
            }
        }
        public SearchControl()
        {
            InitializeComponent();
        }
        public void SetAutoComplete(params string[] values)
        {
            //searchText.AutoCompleteCustomSource.Clear();
            searchText.Values = values;
            //searchText.AutoCompleteCustomSource.AddRange(values);

        }
        public void DoSearch()
        {
            if (SearchedText == string.Empty)
                return;

            this.ActiveControl = searchText;

            searchText.SelectAll();
            OnSearch?.Invoke(this, new SearchEventArgs(this) { SameSearch = prevSearch == SearchedText });

            prevSearch = SearchedText;
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        public void ClearField()
        {
            searchText.Clear();
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            if (searchText.TextLength == 0 && SearchDone)
            {
                OnTextEmpty?.Invoke(this, null);
                SearchDone = false;
                prevSearch = "";
            }
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DoSearch();
        }

        private void searchText_Enter(object sender, EventArgs e)
        {
            searchText.SelectAll();
        }

        private void SearchControl_Load(object sender, EventArgs e)
        {
            searchText.KeyDown += searchText_KeyDown;
            searchText.TextChanged += searchText_TextChanged;
        }
    }
}
