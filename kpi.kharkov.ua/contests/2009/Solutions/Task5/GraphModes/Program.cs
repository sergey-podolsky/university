using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;

namespace GraphModes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var file = new System.IO.StreamWriter("MyGAdapterModes.doc", append:true))
                foreach (DisplayMode mode in Manager.Adapters[0].SupportedDisplayModes)
                {
                    var s = string.Format("{0}x{1}, {2} Hz, Format: {3}", mode.Width, mode.Height, mode.RefreshRate, mode.Format);
                    Console.WriteLine(s);
                    file.WriteLine(s);
                }
        }
    }
}
