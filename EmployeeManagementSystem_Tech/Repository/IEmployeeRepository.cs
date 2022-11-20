using EmployeeManagementSystem_Tech.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployeeAsync();

        Task<EmployeeModel> GetEmployeeDetailsByIdAsync(int employeeId);

        Task<string> AddNewEmployeeAsync(EmployeeModel employeeModel);

        Task UpdateEmployeeDetailsByIdAsync(int employeeId, EmployeeModel employeeModel);

        Task UpdateEmployeeByIdPatchAsync(int employeeId, JsonPatchDocument employeeModel);

        Task DeleteEmployeeByIdAsync(int employeeId);



    }
}
