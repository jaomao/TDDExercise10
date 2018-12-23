namespace CDWarehouse
{
    public class Customer
    {
        public string Name { get; private set; }

        public CreditCard CreditCard { get; private set; }

        public Customer(string Name)
        {
            this.Name = Name;
        }
    }
}