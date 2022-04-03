using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Shops
{
    internal class AbstractShop
    {
        List<Card> _Catalog = new List<Card>();
        public void AddToCatalog(IShop shop)
        {
            _Catalog.Add(new Card()
            {
                Cost = shop.GetCost(),
                Name = shop.GetProductName()
            });
        }

        public List<Card> GetCatalog() => _Catalog;
    }

    public struct Card
    {
        public int Cost { get; set; }
        public string Name { get; set; }
    }
}
