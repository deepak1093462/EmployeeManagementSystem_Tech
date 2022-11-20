using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EmployeeManagementSystem_Tech.Data
{
    public class WorkingHourTable
    {
        [Key]
        public int SNo { get; set; }
        public string Month { get; set; }
        public int CompanyWorkingHour { get; set; }
        public int EmployeeWorkingHour { get; set; }
    }
}
