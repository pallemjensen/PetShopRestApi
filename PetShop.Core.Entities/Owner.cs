﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Owner
    {
        public int OwnerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int PetOwnedId { get; set; }
    }
}
