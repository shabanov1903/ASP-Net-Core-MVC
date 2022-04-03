using Lesson4.Shops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Shops
{
    internal class MeetShop : IShop
    {
        private Meet __Product;

        public MeetShop(Meet product)
        {
            __Product = product;
        }

        public int GetCost()
        {
            return __Product.Money;
        }

        public string GetProductName()
        {
            return __Product.Animal;
        }
    }
}
