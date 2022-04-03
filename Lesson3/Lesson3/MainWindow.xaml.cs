using Lesson3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleRGB rgb;
        public MainWindow()
        {
            InitializeComponent();
            
            rgb = SimpleRGB.Create()
                           .AddRedColorControl(LevelRed)
                           .AddGreenColorControl(LevelGreen)
                           .AddBlueColorControl(LevelBlue)
                           .Build();

            rgb.ColorChanged += Rgb_ColorChanged;
        }

        private void Rgb_ColorChanged(object? sender, SolidColorBrush e)
        {
            ShowWindow.Background = e;
        }

        private void ButtonCalc_Click(object sender, RoutedEventArgs e)
        {
            rgb.Calculate();
        }
    }
}
