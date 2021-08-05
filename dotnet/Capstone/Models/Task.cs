using System;
using System.Collections.Generic;
using System.Linq;



namespace Capstone.Models
{
    public class Task
    {
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public int PropertyId { get; set; }
        public bool IsUrgent { get; set; }
    }
}
