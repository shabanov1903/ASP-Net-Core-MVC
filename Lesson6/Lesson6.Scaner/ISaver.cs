using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.Scaner
{
    public interface ISaver
    {
        public void Save(string file, string path);
    }
}
