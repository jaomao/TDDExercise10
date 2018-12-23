using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CDWarehouse
{
    public class CD : INamed, IRated, IRentable
    {
        public string Title { get; }

        public string Author { get; }

        public int NumberOfCopies { get; private set; }

        public int AvailableCopies { get; private set; }

        public List<IRating> Ratings { get; private set; }

        public bool IsAvailable { get => AvailableCopies > 0; }

        public CD(string Title, string Author, int NumberOfCopies)
        {
            this.Title = string.IsNullOrWhiteSpace(Title) ? throw new ArgumentException() : Title;
            this.Author = string.IsNullOrWhiteSpace(Author) ? throw new ArgumentException() : Author;
            this.NumberOfCopies = NumberOfCopies < 1 ? throw new ArgumentOutOfRangeException() : NumberOfCopies;
            this.AvailableCopies = NumberOfCopies;
            this.Ratings = new List<IRating>();
        }

        public void Rate(double Rate, string Review)
        {
            this.Ratings.Add(new Rating(Rate, Review));
        }

    }
}
