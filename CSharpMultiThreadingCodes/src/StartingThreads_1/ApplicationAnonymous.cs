/// <summary>
/// Contains code examples related to multi-threading in C#.
/// </summary>
namespace CSharpMultiThreadingCodes
{
    /// <summary>
    /// Represents the entry point of the application that starts a new thread using an anonymous method.
    /// </summary>
    public class ApplicationAnonymous
    {
        public static void Main()
        {
            // The thread id of the main thread.
            Console.WriteLine("Hello: Thread in beggining: " + Thread.CurrentThread.ManagedThreadId);
            Thread thread1 = new Thread(delegate (){
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
            });

            thread1.Start();

            thread1.Join();
        }
    }
}