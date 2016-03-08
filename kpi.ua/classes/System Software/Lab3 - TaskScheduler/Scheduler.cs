using System;
using System.Collections.Generic;

namespace TaskScheduler
{
    class Scheduler
    {
        /// <summary>
        /// List of all tasks that ever enetred the system
        /// </summary>
        public List<Task> TasksEntered = new List<Task>();

        /// <summary>
        /// List of all tasks that leaved the system
        /// </summary>
        public List<Task> TasksLeaved = new List<Task>();

        /// <summary>
        /// Local current time moment
        /// </summary>
        protected int time = 0;

        /// <summary>
        /// Current time moment
        /// </summary>
        public int Time
        {
            get { return time; }
            set { while (value > time) IncreaseTime(); }
        }

        /// <summary>
        /// Total processor idle time
        /// </summary>
        public int IdleTime = 0;

        /// <summary>
        /// Add task to system
        /// </summary>
        /// <param name="task">Task to add</param>
        public virtual void AddTask(Task task)
        {
            task.StartTime = time;
            TasksEntered.Add(task);
        }

        /// <summary>
        /// Complete task
        /// </summary>
        /// <param name="task">Task to complete</param>
        protected virtual void CompleteTask(Task task)
        {
            task.EndTime = time;
            TasksLeaved.Add(task);
            if (TaskCompleted != null) TaskCompleted(task, time);
        }

        /// <summary>
        /// Increase current time moment by 1
        /// </summary>
        protected virtual void IncreaseTime()
        {
            time++;
        }

        /// <summary>
        /// Task completed event handler
        /// </summary>
        /// <param name="task">Task that completed</param>
        /// <param name="time">Time moment when task completed</param>
        public delegate void TaskCompletedEventHandler(Task task, int time);

        /// <summary>
        /// Occurs when any task completed
        /// </summary>
        public event TaskCompletedEventHandler TaskCompleted;
    }
}
