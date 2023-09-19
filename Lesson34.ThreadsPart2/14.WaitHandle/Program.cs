using System;
using System.Threading;

namespace WaitHandleNs
{
    class Program
    {
        static WaitHandle[] events = new WaitHandle[]
        {
            new AutoResetEvent(false), // 0
            new AutoResetEvent(false)  // 1
        };

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // İki task-ı thread poola yerləşdirmək. 
            ThreadPool.QueueUserWorkItem(Task1, events[0]);
            ThreadPool.QueueUserWorkItem(Task2, events[1]);

            Console.WriteLine("Hər iki task-ın işini bitirməsini gözləmək.");
            WaitHandle.WaitAll(events);

            // İki task-ı thread poola yerləşdirmək. 
            ThreadPool.QueueUserWorkItem(Task1, events[0]);
            ThreadPool.QueueUserWorkItem(Task2, events[1]);

            Console.WriteLine("\nHər hansı task-lardan birinin işini bitirməsini gözləmək.");
            int index = WaitHandle.WaitAny(events);
            Console.WriteLine("\nTask{0} birini işini bitirdi.", index + 1);

            // Delay
            Console.ReadKey();
        }

        static void Task1(Object state)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("1 ");
                Thread.Sleep(500);
            }
            (state as AutoResetEvent).Set();
        }

        static void Task2(Object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("2 ");
                Thread.Sleep(500);
            }
            (state as AutoResetEvent).Set();
        }
    }
}
