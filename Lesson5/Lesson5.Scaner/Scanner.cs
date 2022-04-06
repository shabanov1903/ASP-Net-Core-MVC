using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Scaner
{
    public class Scanner : IScanning
    {
        public string GetData(string file)
        {
            string str = string.Empty;
            using (StreamReader sr = File.OpenText(file))
            {
                str = sr.ReadToEndAsync().Result;
            }
            return str;
        }
    }
}
