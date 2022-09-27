using RazorEngineCore;
using Engine = RazorEngineCore.RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Reporter.Elements
{
    public class Body : IReport
    {
        private IRazorEngine engine = new Engine();

        private string _parameter;
        private string _value;

        public Body(string parameter, string value)
        {
            _parameter = parameter;
            _value = value;
        }

        public void Generate(string path)
        {
            IRazorEngineCompiledTemplate template = engine.Compile("@Model.Parameter: @Model.Value");

            string result = template.Run(new
            {
                Parameter = _parameter,
                Value = _value
            });

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(result);
            }
        }
    }
}
