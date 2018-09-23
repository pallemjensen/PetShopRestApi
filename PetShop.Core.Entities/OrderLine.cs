﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public class OrderLine
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Qty { get; set; }
    }
}
