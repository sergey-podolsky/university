using System;
using System.Runtime.InteropServices;

namespace ProcessScheduler
{
    public static class API
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

        [DllImport("kernel32.dll")]
        public static extern int SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        public static extern int ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        public static extern bool TerminateThread(IntPtr hThread, int dwExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);
    }
}
