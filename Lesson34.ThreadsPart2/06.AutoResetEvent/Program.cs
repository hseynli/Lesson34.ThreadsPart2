using System;
using System.Threading;

// AutoResetEvent - gözləyən thread-a xəbər verir ki, hər-hansı hadisə baş verib. 

namespace EventWaitHandleNs
{
    class Program
    {
        // Arqument:
        // false - siqnal olmayan vəziyyətə gətirmək.
        static AutoResetEvent auto = new AutoResetEvent(false);

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Thread thread = new Thread(Function);
            thread.Start();
            Thread.Sleep(500); // İkinci thread-a işləmək üçün vaxt verək.

            Console.WriteLine("AutoResetEvent-i siqnal vəziyyətinə gətirmək üçün istənilən düyməni sıxın.\n");
            Console.ReadKey();
            auto.Set(); // İkinci thread-in işini davam etdirmək.

            Console.WriteLine("AutoResetEvent-i siqnal vəziyyətinə gətirmək üçün istənilən düyməni sıxın.\n");
            Console.ReadKey();
            auto.Set(); // İkinci thread-in işini davam etdirmək.

            // Delay
            Console.ReadKey();
        }

        static void Function()
        {
            Console.WriteLine("Qırmızı işıq");
            auto.WaitOne(); // İkinci thread-in işini dayandırmaq.

            Console.WriteLine("Sarı");
            auto.WaitOne(); // İkinci thread-in işini dayandırmaq.

            Console.WriteLine("Yaşıl");

            // QEYD:
            // WaitOne() metodu işini bitirdikdən sonra - AutoResetEvent avtomatik olaraq siqnal olmayan vəziyyətə keçir.
        }
    }
}
