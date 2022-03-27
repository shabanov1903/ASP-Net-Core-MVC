using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Core
{
    public interface IFibonacci
    {
        public void Start();
        public void Stop();
        public void SetDelay(int delay);
    }
}
