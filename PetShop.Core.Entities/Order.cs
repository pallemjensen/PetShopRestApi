using System;

namespace PetShop.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Customer Customer { get; set; }
    }
}