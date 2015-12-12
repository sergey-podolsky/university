using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
// LockCookie
// AutoResetEvent
// ManualResetEvent

namespace _22._09._2009
{
    class Program
    {
        static Random rnd = new Random();
        static byte[] buffer = new byte[100];
        static Thread writer;

        static ReaderWriterLock locker = new ReaderWriterLock();


        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
                buffer[i] = (byte)(i + 1); // sum = 5050
            writer = new Thread(new ThreadStart(WriterFunc));
            writer.Start();
            Thread[] readers = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                readers[i] = new Thread(new ThreadStart(ReaderFunc));
                readers[i].Name = (i + 1).ToString();
                readers[i].Start();
            }
        }

        static void WriterFunc()
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).Seconds < 3)
            {
                int j = rnd.Next(0, 100);
                int k = rnd.Next(0, 100);
                Monitor.Enter(buffer);
                //locker.AcquireWriterLock(Timeout.Infinite);
                try
                {
                    byte t = buffer[j];
                    buffer[j] = buffer[k];
                    buffer[k] = t;
                }
                finally
                {
                    Monitor.Exit(buffer);
                    //locker.ReleaseWriterLock();
                }
            }
            Console.WriteLine("Total iterations : {0} ({1})", total ,total.ToString().Length.ToString());
        }

        static long total = 0;

        static void ReaderFunc()
        {
            for (int i = 0; writer.IsAlive; i++)
            {
                int sum = 0;
                //locker.AcquireReaderLock(Timeout.Infinite);
                Monitor.Enter(buffer);
                //lock (buffer)
                {
                    try
                    {
                        for (int k = 0; k < 100; k++)
                            sum += buffer[k];
                    }
                    finally
                    {
                        Monitor.Exit(buffer);
                        //locker.ReleaseReaderLock();
                    }
                }
                total += i;
                //Console.WriteLine("Thread {0}, sum = {1}, iterations = {2}", Thread.CurrentThread.Name, sum, i);
            }
        }
    }
}
