using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.CrossCutting.ExceptionManager.Exceptions
{
    public class TaskStatusIsNotCompleted : Exception
    {
        public TaskStatusIsNotCompleted() : base("The task status is not completed!")
        {
        }
    }
}
