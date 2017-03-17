using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProcessScheduler
{
    public class ProcessModel
    {
        public readonly string ID;

        readonly string Path;
        readonly UInt64 Iterations;
        Process process;

        public TimeSpan TotalTime
        {
            get
            {
                return exitTime - StartTime;
            }
        }

        TimeSpan workTime;
        public TimeSpan WorkTime
        {
            get
            {
                return workTime;
            }
        }

        public TimeSpan SuspendTime
        {
            get
            {
                return TotalTime - workTime;
            }
        }

        public DateTime StartTime;

        DateTime exitTime;
        public DateTime ExitTime
        {
            get
            {
                return exitTime;
            }
        }

        DateTime lastResumed;

        bool active = false;
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                if (value)
                {
                    if (!active)
                        if (process == null)
                        {
                            try
                            {
                                process = Process.Start(Path, Iterations.ToString() + " " + ID);
                                process.EnableRaisingEvents = true;
                                process.Exited += new EventHandler(process_Exited);
                                lastResumed = DateTime.Now;
                                active = true;
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Помилка відкриття файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (!process.HasExited)
                        {
                            ProcessManager.ResumeProcess(process);
                            active = true;
                            lastResumed = DateTime.Now;
                        }
                }
                else if (active && (process != null) && !process.HasExited)
                {
                    ProcessManager.SuspendProcess(process);
                    workTime += DateTime.Now - lastResumed;
                    active = false;
                }
            }
        }

        public ProcessModel(string path, UInt64 iterations, string Id)
        {
            Path = path;
            Iterations = iterations;
            ID = Id;
        }

        public delegate void ProcessExitedEventHandler(ProcessModel sender);
        public event ProcessExitedEventHandler Exited;
        void process_Exited(object sender, EventArgs e)
        {
            exitTime = DateTime.Now;
            if (active) workTime += exitTime - lastResumed;
            active = false;
            if (Exited != null) Exited(this);
        }

        public void Terminate()
        {
            ProcessManager.TerminateProcess(process);
        }
    }
}
