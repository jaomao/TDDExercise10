using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDWarehouse
{
    public class CDStats
    {
        public IRated CD { get; private set; }

        public CDStats(IRated CD) => (this.CD) = (CD);

        public double getAverageRating()
        {
            if (CD.Ratings.Count == 0) return 0;

            double totalRating = CD.Ratings.Average(x => x.Rate);

            return totalRating;
        }
    }
}
