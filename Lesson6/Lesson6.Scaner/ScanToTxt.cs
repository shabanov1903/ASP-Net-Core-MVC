using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.Scaner
{
    public class ScanToTxt : ISaver
    {
        IScanning _Scanner;
        public ScanToTxt(IScanning scanner) => _Scanner = scanner;
        public void Save(string file, string path)
        {
            string ex = ".txt";
            string str = _Scanner.GetData(file);

            var scanNum = 0;
            while (File.Exists(path + @"\scan" + scanNum + ex))
            {
                scanNum++;
            }

            using (StreamWriter sw = File.CreateText(path + @"\scan" + scanNum + ex))
            {
                if (str != String.Empty) sw.WriteAsync(str);
            }
        }
    }
}
