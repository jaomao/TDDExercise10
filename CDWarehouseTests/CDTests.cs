using System;
using System.Collections.Generic;
using CDWarehouse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CDWarehouseTests
{
    [TestClass]
    public class CDTests
    {
        public CD CreateCD(string Title, string Author, int NumberOfCopies)
        {
            return new CD(Title, Author, NumberOfCopies);
        }

        public static object[] ValidNumberOfCopies
        {
            get => new[] {  new object[] { 1 }, new object[] { 4 }, new object[] { 15 } };
        }

        [DynamicData("ValidNumberOfCopies")]
        [DataTestMethod]
        public void OnCreateNumberOfCopiesEqualsToAvailableCopies(int InitialNumberOfCopies)
        {
            CD CD = CreateCD("Title", "Author", InitialNumberOfCopies);
            Assert.AreEqual(CD.NumberOfCopies, CD.AvailableCopies);
        }

        [DataRow(-15)]
        [DataRow(-3)]
        [DataRow(0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataTestMethod]
        public void OnCreateIfNumberOfCopiesIsLowerThan1ThrowsArgumentOutOfRangeException(int InitialNumberOfCopies)
        {
            CD CD = CreateCD("Title", "Author", InitialNumberOfCopies);
        }

        [DataRow("   ")]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        [DataTestMethod]
        public void OnCreateIfTitleIsNullOrWhiteSpaceThrowsArgumentException(string Title)
        {
            CD CD = CreateCD(Title, "Author", 5);
        }

        [DataRow("   ")]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        [DataTestMethod]
        public void OnCreateIfAuthorIsNullOrWhiteSpaceThrowsArgumentException(string Author)
        {
            CD CD = CreateCD("Title", Author, 5);
        }

        [DynamicData("ValidNumberOfCopies")]
        [DataTestMethod]
        public void CDIsAvailableIfNumberOfAvailableCopiesIsGreaterThan0(int NumberOfAvailableCopies)
        {
            CD CD = CreateCD("Title", "Author", NumberOfAvailableCopies);

            Assert.IsTrue(CD.IsAvailable);
        }

        [TestMethod]
        public void AfterCreationThereIs0Ratings()
        {
            IRated CD = CreateCD("Title", "Author", 5);

            Assert.AreEqual(CD.Ratings.Count, 0);
        }

        [TestMethod]
        public void WhenCDIsRatedItShouldBeAddedToRatings()
        {
            CD CD = CreateCD("Title", "Author", 5);
            CD.Rate(8, "Great");
            var rating = new List<IRating>();
            rating.Add(new Rating(8, "Great"));
            CollectionAssert.AreEqual(CD.Ratings, rating, new RatingComparer());
        }

        private class RatingComparer : Comparer<Rating>
        {
            public override int Compare(Rating x, Rating y)
            {
                return x.Rate.CompareTo(y.Rate);
            }
        }
    }

    
}
