using System.Collections.Generic;

namespace PetShop.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}