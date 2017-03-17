using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Periodically send ICMP messages
            for (; ; System.Threading.Thread.Sleep(1000))
            {
                // Create an instance of class Ping
                var icmp = new System.Net.NetworkInformation.Ping();
                // Send ICMP message and wait for reply
                var reply = icmp.Send(IPAddress.Loopback);
                // Write roundtrip tipe to console
                Console.WriteLine("Rountrip time to {0} is {1} ms", reply.Address, reply.RoundtripTime);
            }
        }
    }
}
