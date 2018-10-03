using System.Collections.Generic;

namespace PetShop.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}