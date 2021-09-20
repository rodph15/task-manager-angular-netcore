using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.CrossCutting.ExceptionManager.Exceptions
{
    public class TaskNameAlreadyExistsException : Exception
    {
        public TaskNameAlreadyExistsException() : base("The task name already exists!")
        {
        }
    }
}
