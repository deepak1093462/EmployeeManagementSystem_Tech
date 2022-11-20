using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Models
{
    public class WorkingHourModel
    {
        [Key]
        public int SNo { get; set; }
        public string Month { get; set; }
        public int CompanyWorkingHour { get; set; }
        public int EmployeeWorkingHour { get; set; }
    }
}
