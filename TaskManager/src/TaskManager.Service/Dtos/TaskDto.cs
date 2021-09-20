using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Service.Dtos
{
    public class TaskDto
    {
        [Required]
        public string Name { get; set; }
        public int Priority { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
