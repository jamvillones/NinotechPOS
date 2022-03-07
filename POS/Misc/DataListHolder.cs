using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class DataListHolder
    {
        public object[] Items { get; }

        public DataListHolder(params object[] items)
        {
            Items = items;
        }

        public object this[int i]
        {
            get
            {
                return Items[i];
            }
        }
    }
}
