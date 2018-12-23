using CDWarehouse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDWarehouseTests
{
    [TestClass]
    public class CDStatsTests
    {
        CD CD;
        CDStats Stats;

        public static object[] Ratings
        {
            get => new[] { new object[] { new double[] { 8 } },
                new object[] { new double[] { 4, 9 } },
                new object[] { new double[] { 10, 6, 3 } }
            };
        }

        [TestInitialize]
        public void CreateCDStats()
        {
            CD = new CD("Title", "Author", 5);
            Stats = new CDStats(CD);
        }

        [TestMethod]
        public void NewlyAddedCDShoudHave0AverageRating()
        {
            double AvgRating = Stats.getAverageRating();
            Assert.AreEqual(AvgRating, 0);
        }

        [DynamicData("Ratings")]
        [DataTestMethod]
        public void AverageRatingIsTheAverageOfAddedRatings(double[] Values)
        {
            foreach (double Value in Values)
            {
                CD.Rate(Value, "G8");
            }

            double AvgRating = Stats.getAverageRating();

            Assert.AreEqual(AvgRating, (double)Values.Average());
        }
    }
}
