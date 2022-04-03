using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Shops
{
    internal interface IShop
    {
        public int GetCost();
        public string GetProductName();
    }
}
