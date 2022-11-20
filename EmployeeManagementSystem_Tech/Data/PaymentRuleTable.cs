using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem_Tech.Data
{
    public class PaymentRuleTable
    {
        [Key]
        public int SNo { get; set; }
        public string PaymentRule { get; set; }
        
    }
}
