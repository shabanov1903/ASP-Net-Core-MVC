using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Reporter
{
    public class ReporterManager
    {
        public static Queue<IReport> _reporters = new Queue<IReport>();
        private string _path;

        public ReporterManager(string path)
        {
            _path = path;
        }

        public ReporterManager AddPart(IReport report)
        {
            _reporters.Enqueue(report);
            return this;
        }

        private void Next(IReport reporter)
        {
            reporter.Generate(_path);
            if (_reporters.Count > 0)
            {
                Next(_reporters.Dequeue());
            }
        }

        public void Start()
        {
            if (_reporters.Count > 0)
            {
                Next(_reporters.Dequeue());
            }
        }
    }
}
