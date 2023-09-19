using System;
using System.Threading;

// Qorunan resurlar üçün sinxronizasiya obyekti olan Mutex-dən istifadə

// MutEx - Mutual Exclusion.

namespace MutexSample
{
    class Program
    {
        //static Mutex mutex = new Mutex(); // Prosessorlar arası sinxronizasiya yoxdur
        static Mutex mutex = new Mutex(false, "MyMutex"); // 19 слайд.

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(Function);
                threads[i].Name = i.ToString();
                Thread.Sleep(500);
                threads[i].Start();
            }

            // Delay
            Console.ReadKey();
        }

        static void Function()
        {
            mutex.WaitOne();

            Console.WriteLine("Thread {0} qorunan hissəyə daxil oldu.", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} qorunan hissəni tərk etdi.\n", Thread.CurrentThread.Name);

            mutex.ReleaseMutex();
        }
    }
}
