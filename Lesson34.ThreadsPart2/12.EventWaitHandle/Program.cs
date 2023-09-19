using System;
using System.Threading;

class Program
{
    static EventWaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

    static void Main()
    {
        Thread workerThread = new Thread(WorkerMethod);
        workerThread.Start();

        // Simulate some work.
        Thread.Sleep(5000);

        // Signal the event, which will release the waiting worker thread.
        eventWaitHandle.Set();

        Console.ReadLine();
    }

    static void WorkerMethod()
    {
        Console.WriteLine("Worker thread waiting for event.");
        eventWaitHandle.WaitOne();
        Console.WriteLine("Worker thread received the event.");
    }
}
