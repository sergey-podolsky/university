using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Task4
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, CallbackDelegate lpfn, IntPtr hMod, IntPtr dwThreadId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern int SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        const int WH_MOUSE_LL = 14;
        const int WM_RBUTTONDOWN = 0x0204;
        const int INPUT_MOUSE = 0;
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]   // Not used in this project. Only for example
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]   // Not used in this project. Only for example
        struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;       // Not used in this project. Only for example
            [FieldOffset(4)]
            public HARDWAREINPUT hi;    // Not used in this project. Only for example
        }

        static IntPtr hookHandle = IntPtr.Zero;
        static IntPtr desktopHandle;

        delegate IntPtr CallbackDelegate(int nCode, int wParam, IntPtr lParam);

        static CallbackDelegate callbackDelegate = new CallbackDelegate(CallbackMethod); // To avoid "A callback was made on a garbage collected delegate" exception

        static IntPtr CallbackMethod(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == WM_RBUTTONDOWN)
            {
                Int64 lParamVal = Marshal.ReadInt64(lParam); // lParam value has 8 (not 4!) bytes length
                int x = (int)lParamVal;         // Mouse X-coordinate
                int y = (int)(lParamVal >> 32); // Mouse Y-coordinate

                INPUT mouseDown = new INPUT { type = INPUT_MOUSE, mi = new MOUSEINPUT { dx = x, dy = y, mouseData = 0, dwFlags = MOUSEEVENTF_LEFTDOWN, dwExtraInfo = IntPtr.Zero, time = 0 } };
                INPUT mouseUp = new INPUT { type = INPUT_MOUSE, mi = new MOUSEINPUT { dx = x, dy = y, mouseData = 0, dwFlags = MOUSEEVENTF_LEFTUP, dwExtraInfo = IntPtr.Zero, time = 0 } };

                if (SendInput(4, new INPUT[] { mouseDown, mouseUp, mouseDown, mouseUp }, 28 /*sizeof INPUT in bytes*/) < 4)
                    MessageBox.Show("Unable to send all inputs");
            }
            return CallNextHookEx(hookHandle, nCode, wParam, lParam);
        }

        public Form1()
        {
            InitializeComponent();
            desktopHandle = GetDesktopWindow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "Ready";
            hookHandle = SetWindowsHookEx(idHook: WH_MOUSE_LL, lpfn: callbackDelegate, hMod: GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), dwThreadId: IntPtr.Zero /*Does not work with desktopHandle*/);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(hookHandle);
        }
    }
}
