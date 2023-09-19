using System;
using System.Threading;

// Timer - hər-hansı metodu verilən zaman aralığında icra etmək üçün istifadə edilir.

namespace TimerSample
{
    class Program
    {
        static int maxCount = 10;
        static int counter;

        static void Function(Object state)
        {
            Console.WriteLine("Metodun çağırılması {0}.", ++counter);

            if (counter == maxCount)
            {
                counter = 0;                     // İterasiyanın sıfırlanması.
                (state as AutoResetEvent).Set(); // Əsas thread-a siqnal göndərir - [davam edir].
            }
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AutoResetEvent auto = new AutoResetEvent(false);
            TimerCallback callback = new TimerCallback(Function);

            Console.WriteLine("Taymerin işləmə periodu 1/10 saniyə.");

            // Arqumentlər:
            // 1. callback - TimerCallback, callback metodu müəyyən edən deleqatdır.
            // 2. auto - verilən metoda ötürülə biləcək arqument və ya null. 
            // 3. dueTime: 1000 - Function metodunun çağırılmasına qalan vaxt (millisaniyə).
            //    [Timeout.Infinite - taymerin işləməsinin qarşısını almaq. (0) dəyəri taymerin həmin an başlaması deməkdir]
            // 4. period: 100 - çağırılacaq metod arasındakı intervalıdır. 
            //    [Timeout.Infinite - periodik çağırılmanı söndürmək]
            Timer timer = new Timer(callback, auto, 1000, 100);

            auto.WaitOne();  // Əsas thread-ı işini dayandırmaq.

            Console.WriteLine("\nTaymerin işləmə periodu 1/2 saniyə.");

            // Arqumentlər:
            // 1. 0 - Callback metodun çağırılmasından əvvəlki zamanı təyin edir.
            // 2. 500 - Callback metodun çağırılması intervalı (millisaniyə).
            timer.Change(0, 500);

            auto.WaitOne();  // Əsas thread-in işini dayandırmaq.

            Console.WriteLine("\nTaymer işini yekunlaşdırdı.");
            timer.Dispose(); // Taymeri dayandırmaq.

            // Delay
            Console.ReadKey();
        }
    }
}
