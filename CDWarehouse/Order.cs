using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDWarehouse
{
    public class Order
    {
        public INamed CD { get; private set; }

        public Customer Customer { get; private set; }

        public Order(INamed CD, Customer Customer)
        {
            this.CD = CD;
            this.Customer = Customer;
        }
    }
}
