using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.CrossCutting.ExceptionManager.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException() : base("The task not found!")
        {
        }
    }
}
