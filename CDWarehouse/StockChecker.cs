using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDWarehouse
{
    public class StockChecker 
    {
        public List<INamed> CDs { get; private set; } = new List<INamed>();

        public StockChecker(List<INamed> CDs)
        {
            this.CDs = CDs;
        }

        public bool HasCDWithTitle(string Title)
        {
            foreach (INamed item in CDs)
            {
                if (string.Equals(item.Title, Title, StringComparison.CurrentCultureIgnoreCase)) return true;
            }

            return false;
        }

        public bool HasCDByAuthor(string Author)
        {
            foreach (INamed item in CDs)
            {
                if (string.Equals(item.Author, Author, StringComparison.CurrentCultureIgnoreCase)) return true;
            }

            return false;
        }

    }
}
