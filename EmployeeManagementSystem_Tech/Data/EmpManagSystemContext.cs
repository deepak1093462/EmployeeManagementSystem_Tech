using EmployeeManagementSystem_Tech.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Data
{
    public class EmpManagSystemContext : IdentityDbContext<ApplicationUserModel>
    {
        public EmpManagSystemContext(DbContextOptions<EmpManagSystemContext> options)
            : base(options)
        {

        }

        public DbSet<EmployeeTable> EmployeeTable { get; set; }

        public DbSet<DesignationTable> DesignationTable { get; set; }
        public DbSet<PaymentRuleTable> PaymentRuleTable { get; set; }
        public DbSet<RequestLeaveTable> RequestLeaveTable { get; set; }
        public DbSet<WorkingHourTable> WorkingHourTable { get; set; }


    }
}
