using System;
using System.Threading;


namespace ManualResetEventNs
{
    class Program
    {
        static AutoResetEvent auto = new AutoResetEvent(false);

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);  // İkinci thread-a işləmək üçün vaxt verək.

            Console.WriteLine("AutoResetEvent-i siqnal vəziyyətinə gətirmək üçün istənilən düyməni sıxın.\n");
            Console.ReadKey();
            auto.Set(); // Yaradılan thread-a siqnal göndəririk.
            auto.Set(); // Digər thread-a siqnal göndəririk.

            // Delay
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Thread 1 yaradıldı və siqnal gözləyir.");
            auto.WaitOne(); // İkinci thread-ı dayandırılması.
            Console.WriteLine("Thread 1 işini bitirdi.");
        }

        static void Function2()
        {
            Console.WriteLine("Thread 2 yaradıldı və siqnal gözləyir.");
            auto.WaitOne(); // Thread 2-nin dayandırılması.
            Console.WriteLine("Thread 2 işini bitirdi.");
        }
    }
}
