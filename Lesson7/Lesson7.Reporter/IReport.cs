using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Reporter
{
    public interface IReport
    {
        public void Generate(string path);
    }
}
