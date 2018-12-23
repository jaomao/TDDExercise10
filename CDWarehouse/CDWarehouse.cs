using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDWarehouse
{
    public class CDWarehouse
    {
        public List<CD> CDs { get; set; }

        public CDWarehouse() => (this.CDs) = (new List<CD>());

        public void Add(List<CD> CDs)
        {
            CDs.AddRange(CDs);
        }
    }
}
