using System;
using System.Collections.Generic;

namespace TaskScheduler
{
    /// <summary>
    /// Round Robin Scheduler
    /// </summary>
    class SchedulerRR : Scheduler
    {
        /// <summary>
        /// Round Robin queue
        /// </summary>
        public Queue<Task> queue = new Queue<Task>();

        /// <summary>
        /// Add task to system
        /// </summary>
        /// <param name="task">Task to add</param>
        public override void AddTask(Task task)
        {
            base.AddTask(task);
            queue.Enqueue(task);
        }

        /// <summary>
        /// Increase current time moment by 1 and do required events
        /// </summary>
        protected override void IncreaseTime()
        {
            base.IncreaseTime();
            if (queue.Count == 0) IdleTime++;
            else
                if (++queue.Peek().WorkTime >= queue.Peek().NecessaryTime)
                    CompleteTask(queue.Dequeue());
                else
                    queue.Enqueue(queue.Dequeue());
        }
    }
}
