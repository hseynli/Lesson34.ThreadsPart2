using System;
using System.Threading;

// ThreadPool.

namespace ThreadPoolNs
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Proqramın işə başladı");            
            
            Report();

            // Task1 metodunu thread pooldan istifadə edərək işə salırıq
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            Report();

            // Task2 metodunu thread pooldan istifadə edərək işə salırıq
            ThreadPool.QueueUserWorkItem(Task2);
            Report();

            Thread.Sleep(3000);
            Console.WriteLine("Proqram işini yekunlaşdırdı");
            Report();

            // Delay
            Console.ReadKey();
        }

        static void Task1(Object state)
        {
            Thread.CurrentThread.Name = "1";
            Console.WriteLine("Thread işə düşdü {0}\n", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} İşini bitirdi\n", Thread.CurrentThread.Name);
        }

        static void Task2(Object state)
        {
            Thread.CurrentThread.Name = "2";
            Console.WriteLine("Thread işə düşdü {0}\n", Thread.CurrentThread.Name);
            Thread.Sleep(500);
            Console.WriteLine("Thread {0} İşini bitirdi\n", Thread.CurrentThread.Name);
        }


        static void Report()
        {
            Thread.Sleep(200);
            int availableWorkThreads, availableIOThreads, maxWorkThreads, maxIOThreads;
            ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
            ThreadPool.GetMaxThreads(out maxWorkThreads, out maxIOThreads);

            Console.WriteLine("Pulda aktiv olan thread-ların sayı  :{1}-dən {0}", availableWorkThreads, maxWorkThreads);
            Console.WriteLine("IO Threadların aktiv satı           :{1}-dən {0}\n", availableIOThreads, maxIOThreads);
        }
    }
}
