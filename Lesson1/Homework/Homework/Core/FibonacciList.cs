using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Core
{
    public class FibonacciList
    {
        private static List<FibonacciObject> _list = new List<FibonacciObject>();

        public void Push(FibonacciObject el)
        {
            lock(_list)
            {
                _list.Add(el);
            }
        }

        public void Clear()
        {
            lock(_list)
            {
                _list.Clear();
            }
        }

        public ReadOnlyCollection<FibonacciObject> Get() => _list.AsReadOnly();
    }

    public class FibonacciObject
    {
        public int Num { get; set; }
        public int Res { get; set; }

        public FibonacciObject(int num, int res)
        {
            Num = num;
            Res = res;
        }
    }
}
