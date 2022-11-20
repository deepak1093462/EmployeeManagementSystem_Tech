using EmployeeManagementSystem_Tech.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Repository
{
    public interface IWorkingHourRepository
    {
        //   Task<List<EmployeeModel>> GetAllEmployeeAsync();
        Task<List<WorkingHourModel>> GetAllWorkingHourRecordsAsync();

        Task<WorkingHourModel> GetWorkingHourDetailsByIdAsync(int whsno);
        //  Task<string> AddNewEmployeeAsync(EmployeeModel employeeModel);
        Task<string> AddNewWorkingHourAsync(WorkingHourModel workingHourModel);



        // Task UpdateEmployeeDetailsByIdAsync(int employeeId, EmployeeModel employeeModel);
        Task UpdateWorkingHourByNoAsync(int whno, WorkingHourModel workingHourModel);



        //  Task DeleteEmployeeByIdAsync(int employeeId);
        Task DeleteWorkingHourByNoAsync(int whno);


    }
}
