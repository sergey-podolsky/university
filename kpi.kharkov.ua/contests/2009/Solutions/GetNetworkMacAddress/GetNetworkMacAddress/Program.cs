using System;
using System.Net;

namespace GetNetworkMacAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var networkInterface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
                Console.WriteLine(networkInterface.GetPhysicalAddress());
        }
    }
}
