using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lesson3.Services
{
    internal class SimpleRGB : ICommand<SolidColorBrush>
    {
        public event EventHandler<SolidColorBrush> ColorChanged;

        private Slider? _SliderRed { get; set; }
        private Slider? _SliderGreen { get; set; }
        private Slider? _SliderBlue { get; set; }

        private SimpleRGB() { }

        public static SimpleRGB Create()
        {
            return new SimpleRGB();
        }

        public SimpleRGB AddRedColorControl(Slider slider)
        {
            _SliderRed = slider;
            return this;
        }
        public SimpleRGB AddGreenColorControl(Slider slider)
        {
            _SliderGreen = slider;
            return this;
        }
        public SimpleRGB AddBlueColorControl(Slider slider)
        {
            _SliderBlue = slider;
            return this;
        }

        public SimpleRGB Build()
        {
            return this;
        }

        public void Calculate()
        {
            byte r = _SliderRed is not null ? (byte)_SliderRed.Value : byte.MinValue;
            byte g = _SliderGreen is not null ? (byte)_SliderGreen.Value : byte.MinValue;
            byte b = _SliderBlue is not null ? (byte)_SliderBlue.Value : byte.MinValue;
            ColorChanged?.Invoke(this, new SolidColorBrush(Color.FromRgb(r, g, b)));
        }
    }
}
