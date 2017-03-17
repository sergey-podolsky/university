using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProcessScheduler
{
    public static class ThreadManager
    {

        /// <summary>
        /// Thread all control mode
        /// </summary>
        const int allControl = 0x1F03FF;

        /// <summary>
        /// List of threads that where suspended
        /// </summary>
        public static List<int> suspendedThreadsIdList = new List<int>();

        public static void SuspendThread(ProcessThread thread)
        {
            if (suspendedThreadsIdList.Contains(thread.Id)) return;
            IntPtr handle = API.OpenThread(allControl, false, thread.Id);
            API.SuspendThread(handle);
            API.CloseHandle(handle);
            suspendedThreadsIdList.Add(thread.Id);
        }

        public static void ResumeThread(ProcessThread thread)
        {
            if (!suspendedThreadsIdList.Contains(thread.Id)) return;
            IntPtr handle = API.OpenThread(allControl, false, thread.Id);
            API.ResumeThread(handle);
            API.CloseHandle(handle);
            suspendedThreadsIdList.Remove(thread.Id);
        }

        public static void TerminateThread(ProcessThread thread)
        {
            IntPtr handle = API.OpenThread(allControl, false, thread.Id);
            API.TerminateThread(handle, 0);
            API.CloseHandle(handle);
        }
    }
}
