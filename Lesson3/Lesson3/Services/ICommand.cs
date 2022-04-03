using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.Services
{
    public interface ICommand<T>
    {
        /// <summary>
        /// При реализации интерфейса событие должно быть вызвано в конце метода Calculate()
        /// В событии передается информация после выполнения метода Calculate()
        /// </summary>
        public event EventHandler<T> ColorChanged;

        /// <summary>
        /// Метод вызывается извне для расчета параметров заранее сконфигурированного объекта
        /// Информация передается в событии для возможности использования данных не только в месте вызова
        /// </summary>
        public void Calculate();
    }
}
