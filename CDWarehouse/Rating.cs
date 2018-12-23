namespace CDWarehouse
{
    public class Rating : IRating
    {
        public double Rate { get; private set; }

        public string Review { get; private set; }

        public Rating(double Rate, string Review)
        {
            this.Rate = Rate;
            this.Review = Review;
        }
    }
}