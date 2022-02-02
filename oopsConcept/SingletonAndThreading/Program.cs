using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonAndThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //added exception handling
            try
            {
                callMethod();

                //Thread pool

                for (int task = 1; task < 51; task++)
                    ThreadPool.QueueUserWorkItem(
                        new WaitCallback(TaskCallBack), task);
                Thread.Sleep(10000);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                MyThread obj = new MyThread();

                // Creating and initializing
                // threads Unstarted state
                Thread thr1 = new Thread(new ThreadStart(obj.thread));

                Console.WriteLine("ThreadState: {0}",
                                      thr1.ThreadState);

                // Running state
                thr1.Start();
                Console.WriteLine("ThreadState: {0}",
                                   thr1.ThreadState);

                // thr1 is in suspended state
                thr1.Suspend();
                Console.WriteLine("ThreadState: {0}",
                                   thr1.ThreadState);

                // thr1 is resume to running state
                thr1.Resume();
                Console.WriteLine("ThreadState: {0}",
                                  thr1.ThreadState);
                Console.ReadLine();
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }
        }
        public static async void callMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }

        private static void TaskCallBack(Object ThreadNumber)
        {
            string ThreadName = "Thread " +
                ThreadNumber.ToString();
            for (int i = 1; i < 10; i++)
                Console.WriteLine(ThreadName
                    + ": " + i.ToString());
            Console.WriteLine(ThreadName
                + "Finished...");
        }
    }

    public class MyThread
    {

        // Non-Static method
        public void thread()
        {
            for (int x = 0; x < 2; x++)
            {
                Console.WriteLine("My Thread");
            }
        }
    }


}