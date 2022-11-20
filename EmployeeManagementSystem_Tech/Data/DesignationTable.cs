using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Data
{
    public class DesignationTable
    {
        [Key]
        public int SNo { get; set; }
        public string DesigName { get; set; }
        public string RoleName { get; set; }
        public string DeptName { get; set; }
    }
}
