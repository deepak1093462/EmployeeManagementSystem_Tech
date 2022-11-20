using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem_Tech.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        [StringLength(10)]
        public string EmpPhone { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
    }
}
