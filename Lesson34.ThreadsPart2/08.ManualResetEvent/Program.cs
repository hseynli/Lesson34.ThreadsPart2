using System;
using System.Threading;

// ManualResetEvent - bir və ya daha artıq thread-ə hadisənin baş verdiyini xəbərdar edir.

namespace ManualResetEventNs
{
    class Program
    {
        // Arqument:
        // false - siqnalolmayan vəziyyətə gətirir.
        static ManualResetEvent manual = new ManualResetEvent(false);

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);  // Digər thread-lara işləmək üçün vaxt verək.

            Console.WriteLine("ManualResetEvent-i siqnal vəziyyətinə gətirmək üçün istənilən klavişə basın.\n");
            Console.ReadKey();
            manual.Set(); // Bütün thread-lara siqnal göndərir.

            // Delay
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Thread 1 işə başladı və siqnal gözləyir.");
            manual.WaitOne(); // Yeni yaradılan thread-in işini dayandırmaq.
            Console.WriteLine("Thread 1 işini yekunlaşdırdı.");
        }

        static void Function2()
        {
            Console.WriteLine("Thread 2 işə başladı və siqnal gözləyir.");
            manual.WaitOne(); // Yeni yaradılan thread 2-nin işini dayandırmaq.
            Console.WriteLine("Thread 2 işini yekunlaşdırdı.");
        }
    }
}
