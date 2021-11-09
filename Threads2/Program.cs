using System;
using System.Threading;

namespace Threads2
{
    internal class Program
    {

        static long Sum0To300()
        {
            long sum = 0;
            for (int i = 0; i <= 300; i++)
            {
                sum = sum + i;
                Console.WriteLine(sum);
            }
            return sum;
        }

        static long Sum300To600()
        {
            long sum = 0;
            for (int i = 301; i <= 599; i++)
            {
                sum = sum + i;
            }
            Console.WriteLine(sum);
            return sum;
        }


        static void Main(string[] args)
        {
            //Local variables to use, each for a diffrent thread, this way is thread safe
            //with no need for synchronization, since there are no shared resources
            long sum1 = 0, sum2 = 0;

            //We are rturning values from thread1 (into sum 1) and thread2 (into sum2)
            Thread thread1 = new Thread(() => { sum1 = Sum0To300(); });
            Thread thread2 = new Thread(() => { sum2 = Sum300To600(); });

            thread2.Start();
            thread1.Start();

            // Wait for thread1/thread2 to finish it's job and terminate, meanwhile current thread is waiting
            // If we don't wait the results of (sum1 + sum2) are not expected, since it may print before the calculation of summ 1 or while it is still calculating
            thread1.Join(); 
            thread2.Join();

            Console.WriteLine("Sum = " + sum1 + sum2);
        }
    }
}
