using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ProcessModel
{
    class Program
    {
        static void Main(string[] args)
        {
            UInt64 iterations = 1000;
            string ID = "";
            try
            {
                iterations = Convert.ToUInt64(args[0]);
                ID = "Process N " + args[1].ToString() + ": ";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\nEntering default mode: " + iterations.ToString() + " iterations\n");
            }
            for (UInt64 i = 0; i < iterations; i++)
                Console.WriteLine(ID + i.ToString());
            Console.WriteLine("Done.\nTerminating...");
        }
    }
}
