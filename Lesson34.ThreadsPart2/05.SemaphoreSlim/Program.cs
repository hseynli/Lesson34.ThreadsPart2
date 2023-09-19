using System;
using System.Threading;

// SemaphoreSlim - semaforun daha yüngül varinatıdır
// [əməliyyat sisteminin obyektlərindən istifadə etmir].

namespace MyNamespace
{
    public class Program
    {
        static SemaphoreSlim pool;

        static void Function(object number)
        {
            pool.Wait();

            Console.WriteLine("Thread {0} semaforun slotunu tutdu.", number);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} -----> slotu boşaltdı.", number);

            pool.Release();
        }

        public static void Main()
        {
            pool = new SemaphoreSlim(2, 4);

            for (int i = 1; i <= 8; i++)
            {
                new Thread(Function).Start(i);
            }

            // Delay
            Console.ReadKey();
        }
    }
}
