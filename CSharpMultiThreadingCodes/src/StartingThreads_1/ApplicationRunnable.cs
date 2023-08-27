namespace CSharpMultiThreadingCodes
{
    public class ApplicationRunnable
    {
        public static void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                // CSharp's default Thread Name is null. According to the documentation, https://learn.microsoft.com/zh-tw/dotnet/api/system.threading.thread.name?view=net-7.0
                // So, We use Thread.CurrentThread.ManagedThreadId to get the thread id instead.
                Console.WriteLine("Hello: " + i + " Thread: " + Thread.CurrentThread.ManagedThreadId);
                try
                {
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException ignored)
                {
                }
            }
        }
        

        public static void Main()
        {
            // The thread id of the main thread.
            Console.WriteLine("Hello: Thread in beggining: " + Thread.CurrentThread.ManagedThreadId);
            
            Thread thread1 = new Thread(Run);
            thread1.Start();

            Thread thread2 = new Thread(Run);
            thread2.Start();

            // Wait for the threads to finish.
            thread1.Join();
            thread2.Join();
        }
    }
}
