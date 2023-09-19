using System;
using System.Threading;

// Thread poolda yerləşən thread-ların bloklanması [ThreadPool].

namespace RegistredWaitHandleNs
{
    class Program
    {
        static void CallBackFunction(object state, bool timedOut)
        {
            Console.WriteLine("Signal");
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AutoResetEvent auto = new AutoResetEvent(false);
            WaitOrTimerCallback callback = new WaitOrTimerCallback(CallBackFunction);

            // Arqumentlər:
            // 1. auto - kimdən siqnal gözləmək lazımdır.
            // 2. callback - nəyi icra etmək lazımdır.
            // 3. null - Callback metodun 1-ci arqumenti.
            // 4. 2000 - Callback metodun çağırılma intervalı.
            // 5. true - Callback metodu bir dəfə çağırmaq. false - Callback metodu intervalla çağırmaq.

            RegisteredWaitHandle handle = ThreadPool.RegisterWaitForSingleObject(auto, callback, null, 2000, false);
            //RegisteredWaitHandle handle = ThreadPool.RegisterWaitForSingleObject(auto, callback, null, Timeout.Infinite, true);

            Console.WriteLine("S - siqnal, Q - çıxış");

            while (true)
            {
                string operation = Console.ReadKey(true).KeyChar.ToString().ToUpper();

                if (operation == "S")
                {
                    auto.Set();
                }
                if (operation == "Q")
                {
                    handle.Unregister(auto);
                    break;
                }
            }

            // Delay
            Console.ReadKey();
        }
    }
}
