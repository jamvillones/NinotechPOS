using System;
using System.Windows.Forms;

namespace POS
{
    public class SearchHandler
    {
        /// <summary>
        /// the actual textbox reference
        /// </summary>
        private TextBox textbox = null;
        /// <summary>
        /// the set of textbox reference
        /// </summary>
        public TextBox ReferencedTextbox
        {
            set
            {
                if (textbox != null)
                {
                    textbox.KeyDown -= Textbox_KeyDown;
                    textbox.TextAlignChanged -= TextChangedMethod;
                }

                textbox = value;
                textbox.KeyDown += Textbox_KeyDown;
                textbox.TextChanged += TextChangedMethod;

            }
        }
        /// <summary>
        /// event for when text box is cleared
        /// </summary>
        public event EventHandler OnTextCleared;
        /// <summary>
        /// the actual event for searching
        /// </summary>
        public event EventHandler<SearchHandler> OnSearch;
        /// <summary>
        /// this stores the previos text searched
        /// </summary>
        private string prevSearch { get; set; }
        /// <summary>
        /// stores the value of the search
        /// </summary>
        public string SearchedString { get; private set; }
        /// <summary>
        /// this determines the if the search is not changed
        /// </summary>
        public bool SameSearch { get; private set; } = false;
        /// <summary>
        /// this determines the successful search, must be set to the actual callback for the textcleared to fire
        /// </summary>
        public bool SeachFound { get; set; } = false;
        /// <summary>
        /// determines wether the textbox should be selected after search
        /// </summary>
        public bool SelectAllAfterSearch { get; set; } = true;
        /// <summary>
        /// the method to initiate search
        /// </summary>
        public void PerformSearch()
        {
            if (textbox == null)
                throw new NullReferenceException("Textbox is not set;");

            var text = textbox.Text.Trim();

            if (text == string.Empty)
                return;

            SameSearch = text == prevSearch;
            SearchedString = text;

            OnSearch?.Invoke(null, this);

            SearchedString = string.Empty;

            if (SelectAllAfterSearch)
            {
                var f = textbox.FindForm();
                f.ActiveControl = textbox;
                textbox.SelectAll();
            }
        }
        /// <summary>
        /// enter key callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textbox == null)
                    throw new NullReferenceException("Textbox is not set;");

                PerformSearch();
            }
        }
        /// <summary>
        /// used for refresh after the textbox is emptied
        /// </summary>
        private void TextChangedMethod(object sender, EventArgs e)
        {
            var text = textbox?.Text.Trim();

            if (text == string.Empty && SeachFound)
            {
                OnTextCleared?.Invoke(this, null);

                SeachFound = false;
                SameSearch = false;
            }
        }
    }
}
