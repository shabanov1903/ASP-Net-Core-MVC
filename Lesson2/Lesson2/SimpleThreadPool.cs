using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lesson2
{
    public class SimpleThreadPool
    {
        private int _countMax = 10;

        private ConcurrentQueue<Action> _queueOfTask;
        private List<Thread> _listOfTask;

        public SimpleThreadPool(int counts)
        {
            if (counts <= _countMax)
            {
                _countMax = counts;
            }
            else
            {
                throw new ArgumentException(message: $"Maximum count number of new Threads is {_countMax}");
            }

            _queueOfTask = new ConcurrentQueue<Action>();

            _listOfTask = new List<Thread>();
            for (int i = 0; i < _countMax; i++)
            {
                _listOfTask.Add(new Thread(ThreadTask));
            }

            var iCount = 0;
            _listOfTask.ForEach(x => {
                x.IsBackground = true;
                x.Name = $"Custom Thread {iCount}";
                x.Start();
                iCount++;
            });
        }

        private void ThreadTask()
        {
            while (true)
            {
                if (!_queueOfTask.IsEmpty)
                {
                    Action task;
                    var check = _queueOfTask.TryDequeue(out task);
                    if (check)
                    {
                        task();
                    }
                }
            }
        }

        public void AddTask(Action action) => _queueOfTask.Enqueue(action);
    }
}
