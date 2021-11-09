using System;
using System.Threading;

namespace Threads2
{
    internal class Program
    {
        static long sum = 0;

        static object lockObject = new object();


        static void AddToSum(long value)
        {
            //Try runing this code without the Lock a fe times
            //you will see that you get diffrent unexpected results
            //because one thread is changing the results of 'sum'
            //before the end of comutation of the other thread
            lock (lockObject)
            {
                sum = sum + value;
            }
        }


        //The big job in one thread
        static void ZeroTo6000()
        {
            for (int i = 0; i < 6000; i++)
            {
                /**** We don't want to use the line below  (sum = sum + i), 
                 * because another thread is also updating sum
                 * 
                 * Both threads are compiting the same resource
                 * we sould use lock instead to make sure that 
                 * ********************************/
                //sum = sum + i;

                AddToSum(i);
            }
        }

        /// <summary>
        /// Part 1
        /// We are deviding the big work to smaller parts
        /// </summary>
        static void ZeroTo3000()
        {
            for (int i = 0; i <= 3000; i++)
            {

                AddToSum(i);
            }
        }

        /// <summary>
        /// Part 2
        /// See above "Part 1"
        /// </summary>
        static void T3000To6000()
        {
            for (int i = 3001; i < 6000; i++)
            {
                sum += i;
            }
        }



        static void Main(string[] args)
        {

            var t1 = new Thread(() => ZeroTo3000());
            var t2 = new Thread(() => T3000To6000());

            t1.Start();
            t2.Start();

            t1.Join();//Waits for t1 to signal it's done and terminated, meanwhile current thead is awaiting
            t2.Join();

            Console.WriteLine("Sum = " + sum);


        }
    }
}
