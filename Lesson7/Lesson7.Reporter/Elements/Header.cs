using RazorEngineCore;
using Engine = RazorEngineCore.RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Reporter.Elements
{
    public class Header : IReport
    {
        private IRazorEngine engine = new Engine();

        private string _reportName;

        public Header(string reportName)
        {
            _reportName = reportName;
        }

        public void Generate(string path)
        {
            IRazorEngineCompiledTemplate template = engine.Compile("Report @Model.ReportName from @Model.Date");

            string result = template.Run(new
            {
                ReportName = _reportName,
                Date = DateTime.Now
            });

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(result);
            }
        }
    }
}
