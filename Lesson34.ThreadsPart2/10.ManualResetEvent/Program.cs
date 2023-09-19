using System;
using System.Threading;

namespace Event
{
    class Program
    {
        // false - siqnal olmayan vəziyyətə gətirmək.
        static ManualResetEvent manual = new ManualResetEvent(false);

        static void Function()
        {
            Console.WriteLine("{0} nömrəli thread işə düşdü", Thread.CurrentThread.Name);

            for (int i = 0; i < 80; i++)
            {
                Console.Write(".");
                Thread.Sleep(20);
            }

            Console.WriteLine("{0} nömrəli thread işə düşdü", Thread.CurrentThread.Name);

            manual.Set(); // Əsas thread-a siqnal göndərir - [davam edir].
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Thread thread = new Thread(Function) { Name = "1" }; // 1-й ПОТОК.
            thread.Start();

            Console.WriteLine("Əsas thread-in işini dayandırmaq.");
            manual.WaitOne();

            Console.WriteLine("Əsas thread işinə davam edir.");

            manual.Reset(); // Siqnal olmayan vəziyyətə gətirmək [ManualResetEvent(false)].

            thread = new Thread(Function) { Name = "2" }; // 2-ci THREAD.
            thread.Start();

            Console.WriteLine("Əsas thread-in işini dayandırmaq.");
            manual.WaitOne();

            Console.WriteLine("Əsas thread işinə davam edir.");

            // Delay
            Console.ReadKey();
        }
    }
}