using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Task3
{
    static class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, CallbackDelegate lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, int wParam, IntPtr lParam);

        [DllImport("user32")]
        static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpKeyState, out short lpChar, int uFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] keyState);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x0100;
        static IntPtr hookHandle = IntPtr.Zero;
        static Form1 form1;

        delegate IntPtr CallbackDelegate(int nCode, int wParam, IntPtr lParam);

        static CallbackDelegate callbackDelegate = new CallbackDelegate(CallbackMethod); // To avoid "A callback was made on a garbage collected delegate" exception

        static IntPtr CallbackMethod(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == WM_KEYDOWN)
            {
                var keyState = new byte[256];
                short ascii;
                if (GetKeyboardState(keyState) && ToAscii(uVirtKey: Marshal.ReadInt32(lParam), uScanCode: 0, lpKeyState: keyState, lpChar: out ascii, uFlags: 0) != 0)
                    form1.label.Text = ((char)ascii).ToString();
            }
            return CallNextHookEx(hookHandle, nCode, wParam, lParam);
        }

        [STAThread]
        static void Main()
        {
            hookHandle = SetWindowsHookEx(idHook: WH_KEYBOARD_LL, lpfn: callbackDelegate, hMod: GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), dwThreadId: 0);
            Application.Run(form1 = new Form1());
            UnhookWindowsHookEx(hookHandle);
        }
    }
}
