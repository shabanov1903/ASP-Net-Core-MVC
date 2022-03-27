using Homework.Core;
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

namespace Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFibonacci? _fibonacci;
        public MainWindow()
        {
            InitializeComponent();

            _fibonacci = new FibonacciLocal(LabelFibonacci, ListFibonacci);
        }

        private void SliderDelay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(DelayIndicator is not null) DelayIndicator.Text = SliderDelay.Value.ToString();
            _fibonacci?.SetDelay((int)SliderDelay.Value);
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            _fibonacci?.Start();
            ButtonStart.IsEnabled = false;
            ButtonStop.IsEnabled = true;
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            _fibonacci?.Stop();
            ButtonStart.IsEnabled = true;
            ButtonStop.IsEnabled = false;
        }
    }
}
