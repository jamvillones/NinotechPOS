using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Misc
{
    public class SearchEventArgs : EventArgs
    {
        public SearchEventArgs(UserControls.SearchControl s)
        {
            sender = s;
        }
        private UserControls.SearchControl sender;
        public string Text
        {
            get
            {
                return sender.SearchText;
            }
        }
        public bool SearchFound
        {
            get { return sender.SearchDone; }
            set { sender.SearchDone = value; }
        }
    }
}
