using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskScheduler
{
    /// <summary>
    /// Low Latency Queue scheduler
    /// </summary>
    class SchedulerLLQ : Scheduler
    {
        /// <summary>
        /// Common queue to store all tasks
        /// </summary>
        List<Task> queue = new List<Task>();

        /// <summary>
        /// Add task to system
        /// </summary>
        /// <param name="task">Task to add</param>
        public override void AddTask(Task task)
        {
            base.AddTask(task);
            queue.Add(task);
        }

        /// <summary>
        /// Increase current time moment by 1 and do required events
        /// </summary>
        protected override void IncreaseTime()
        {
            base.IncreaseTime();
            if (queue.Count == 0) IdleTime++;
            else if (++queue[0].WorkTime >= queue[0].NecessaryTime)
            {
                CompleteTask(queue[0]);
                queue.RemoveAt(0);
                queue.Sort(new Comparison<Task>(delegate(Task x, Task y)
                    {
                        return
                            x.PriorityClass > y.PriorityClass ? 1 :
                            x.PriorityClass < y.PriorityClass ? -1 :
                            x.Priority > y.Priority ? 1 :
                            x.Priority < y.Priority ? -1 :
                            0;
                    }));
            }
        }
    }
}
