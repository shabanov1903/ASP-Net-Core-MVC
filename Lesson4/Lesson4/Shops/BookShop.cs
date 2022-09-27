using Lesson4.Shops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Shops
{
    internal class BookShop : IShop
    {
        private Book __Product;

        public BookShop(Book product)
        {
            __Product = product;
        }

        public int GetCost()
        {
            return __Product.Price;
        }

        public string GetProductName()
        {
            return __Product.Name;
        }
    }
}
