using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Homework.Core
{
    public class FibonacciLocal : IFibonacci
    {
        private Thread _thread;
        private TextBlock _textBlock;
        private ListView _listView;
        private volatile int _counter = 0;
        private volatile int _delay = 1000;
        private volatile bool __ThreadFlag;
        private FibonacciList _list;

        public FibonacciLocal(TextBlock textBlock, ListView listView)
        {
            _textBlock = textBlock;
            _listView = listView;
            _list = new FibonacciList();
        }

        private void ThreadFunction()
        {
            while (__ThreadFlag)
            {
                var result = Fibonacci(_counter);
                SetResult(result);
                _counter++;
                Thread.Sleep(_delay);
            }
        }

        public void Start()
        {
            __ThreadFlag = true;
            _thread = new Thread(ThreadFunction);
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void Stop()
        {
            __ThreadFlag = false;
        }

        private void SetResult(int result)
        {
            var fibonacci = new FibonacciObject(_counter, result);
            _list.Push(fibonacci);

            _textBlock.Dispatcher.BeginInvoke(() => {
                _textBlock.Text = $"f({_counter - 1}) = {result}";
            });
            _listView.Dispatcher.BeginInvoke(() => {
                _listView.ItemsSource = _list.Get();
            });
        }

        public void SetDelay(int delay)
        {
            _delay = delay * 1000;
        }

        private int Fibonacci(int n)
        {
            if (n == 0 || n == 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
