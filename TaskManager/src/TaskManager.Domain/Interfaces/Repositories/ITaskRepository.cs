﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
    }
}
