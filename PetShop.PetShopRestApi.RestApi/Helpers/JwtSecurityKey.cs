﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace PetShop.PetShopRestApi.RestApi.Helpers
{
    
        public static class JwtSecurityKey
        {
            private static byte[] secretBytes = Encoding.UTF8.GetBytes("A secret default value for HmacSha256");

            public static SymmetricSecurityKey Key
            {
                get { return new SymmetricSecurityKey(secretBytes); }
            }

            public static void SetSecret(string secret)
            {
                secretBytes = Encoding.UTF8.GetBytes(secret);
            }

        }
}

