using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.Scaner
{
    public class ScannerManager
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();
        private ISaver _Scan;
        
        public ScannerManager(ISaver scan) => _Scan = scan;

        public void StartScan(string file, string path)
        {
            _Logger.Info($"Сканирование файла {file} в {path}");
            try
            {
                _Scan.Save(file, path);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex.Message);
            }
        }
    }
}
