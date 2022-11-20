using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Models
{
    public class PaymentRuleModel
    {
        [Key]
        public int SNo { get; set; }
        public string PaymentRule { get; set; }
    }
}
