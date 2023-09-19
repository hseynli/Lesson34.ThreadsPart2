namespace MyNamespace
{
    public class Program
    {
        static Semaphore pool;

        static void Function(object number)
        {
            pool.WaitOne();

            Console.WriteLine("Thread {0} semaforun slotunu tutdu.", number);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} -----> slotu boşaltdı.", number);

            pool.Release();
        }

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            pool = new Semaphore(2, 4, "MySemafore");

            //pool.Release(2); // Semaforu sıfırlamaq - 2-yə icazə vermək.

            for (int i = 1; i <= 8; i++)
            {
                new Thread(Function).Start(i);
                //Thread.Sleep(500);
            }

            // Delay
            Console.ReadKey();
        }
    }
}