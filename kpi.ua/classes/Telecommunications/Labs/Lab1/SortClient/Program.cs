using System;
using System.Net;
using System.Net.Sockets;

namespace SortClient
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) args = new string[] { "127.0.0.1", "9050" };
            else if (args.Length == 1) args = new string[] { args[0], "9050" }; 

            TcpClient client = new TcpClient(AddressFamily.InterNetwork);
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse(args[0]), Int16.Parse(args[1])));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Connected to " + client.Client.RemoteEndPoint.ToString());
            NetworkStream stream = client.GetStream();
            try
            {
                for (; ; )
                {
                    byte[] buffer = new byte[1024];
                    int receivedCount = stream.Read(buffer, 0, buffer.Length);
                    Array.Sort(buffer, 0, receivedCount);
                    stream.Write(buffer, 0, receivedCount);
                    Console.WriteLine(string.Format("{0}:{1}\t{2} bytes sorted", DateTime.Now.ToShortTimeString(), DateTime.Now.Millisecond, receivedCount));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                client.Close();
            }
        }
    }
}