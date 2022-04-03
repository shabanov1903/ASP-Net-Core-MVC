using Lesson4.Shops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Shops
{
    internal class CandyShop : IShop
    {
        private Candy __Product;

        public CandyShop(Candy product)
        {
            __Product = product;
        }

        public int GetCost()
        {
            return __Product.Cost;
        }

        public string GetProductName()
        {
            return __Product.Sweet;
        }
    }
}
