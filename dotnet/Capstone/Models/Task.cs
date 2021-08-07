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
        public string TaskDescription { get; set; }
        public string DateEntered { get; set; }
        public string DateScheduled { get; set; }
        public string TaskStatus { get; set; }
        //landlord id is not in mssql task table using a join to properties
        public int LandlordId { get; set; }

    }
}
