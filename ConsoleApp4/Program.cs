using System;
using System.Threading;

class Program
{
    static int count = 0;
    static object lockObj = new object();

    static void Main(string[] args)
    {
        Thread t1 = new Thread(PrintEvenNumbers);
        Thread t2 = new Thread(PrintOddNumbers);

        t1.Start();
        t2.Start();

        Console.ReadLine();
    }

    static void PrintEvenNumbers()
    {
        while (count <= 10)
        {
            lock (lockObj)
            {
                if (count % 2 == 0)
                {
                    Console.WriteLine(count);
                    count++;
                    Monitor.Pulse(lockObj);
                }
                else
                {
                    Monitor.Wait(lockObj);
                }
            }
        }
    }

    static void PrintOddNumbers()
    {
        while (count <= 10)
        {
            lock (lockObj)
            {
                if (count % 2 == 1)
                {
                    Console.WriteLine(count);
                    count++;
                    Monitor.Pulse(lockObj);
                }
                else
                {
                    Monitor.Wait(lockObj);
                }
            }
        }
    }
}