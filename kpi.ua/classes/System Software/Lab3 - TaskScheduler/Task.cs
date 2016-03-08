using System;
using System.Collections.Generic;

namespace TaskScheduler
{
    class Task
    {
        /// <summary>
        /// Task's priority
        /// </summary>
        public readonly int Priority;

        /// <summary>
        /// Task's priority class
        /// </summary>
        public readonly int PriorityClass;

        /// <summary>
        /// Task weight
        /// </summary>
        public readonly int NecessaryTime;

        /// <summary>
        /// Task work time
        /// </summary>
        public int WorkTime = 0;

        /// <summary>
        /// Time moment when task has incomed to system
        /// </summary>
        public int StartTime = -1;

        /// <summary>
        /// Time moment when task has left system
        /// </summary>
        public int EndTime = -1;

        /// <summary>
        /// Passed time since task has incomed
        /// </summary>
        public int TotalTime
        {
            get
            {
                if (StartTime < 0) throw new Exception("Task start time is not set");
                if (EndTime < 0) throw new Exception("Task end time is not set");
                return EndTime - StartTime;
            }
        }

        /// <summary>
        /// Task idle time since task has incomed
        /// </summary>
        public int IdleTime
        {
            get
            {
                if (TotalTime < WorkTime) throw new Exception("TotalTime < WorkTime");
                return TotalTime - WorkTime;
            }
        }

        /// <summary>
        /// Create new task
        /// </summary>
        /// <param name="necessaryTime">Task weight</param>
        public Task(int necessaryTime, int priority, int priorityClass)
        {
            if ((NecessaryTime = necessaryTime) < 1)
                throw new Exception("Incorrect Task Necessary Time");
            Priority = priority;
            PriorityClass = priorityClass;
        }
    }
}
