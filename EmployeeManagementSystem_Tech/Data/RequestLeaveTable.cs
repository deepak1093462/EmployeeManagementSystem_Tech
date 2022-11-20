using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Data
{
    public class RequestLeaveTable
    {
        [Key]
        public int EmpId { get; set; }
        public string LeaveType { get; set; }
        public DateTime When { get; set; }
        public string LeaveReason { get; set; }
    }
}
