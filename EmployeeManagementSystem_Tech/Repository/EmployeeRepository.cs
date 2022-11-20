using EmployeeManagementSystem_Tech.Data;
using EmployeeManagementSystem_Tech.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpManagSystemContext _context;

        public EmployeeRepository(EmpManagSystemContext context)
        {
            _context = context;
        }


        // Get all employee records 
        public async Task<List<EmployeeModel>> GetAllEmployeeAsync()
        {

            try
            {
                var records = await _context.EmployeeTable.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    EmpName = x.EmpName,
                    EmpPhone = x.EmpPhone,
                    EmpEmail = x.EmpEmail,
                    EmpAddress = x.EmpAddress
                }).ToListAsync();


                return records;
            }
            catch (Exception)
            {
                throw;
            }
            



        }



        // get employee details by id
        public async Task<EmployeeModel> GetEmployeeDetailsByIdAsync(int employeeId)
        {
            try
            {
                var records = await _context.EmployeeTable.Where(x => x.Id == employeeId).Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    EmpName = x.EmpName,
                    EmpPhone = x.EmpPhone,
                    EmpEmail = x.EmpEmail,
                    EmpAddress = x.EmpAddress
                }).FirstOrDefaultAsync();

                return records;
            }
            catch (Exception)
            {
                throw;
            }

        }


        //adding new employee
        public async Task<string> AddNewEmployeeAsync(EmployeeModel employeeModel)
        {
            try
            {
                var employee = new EmployeeTable()
                {
                    EmpName = employeeModel.EmpName,
                    EmpPhone = employeeModel.EmpPhone,
                    EmpEmail = employeeModel.EmpEmail,
                    EmpAddress = employeeModel.EmpAddress
                };

                _context.EmployeeTable.Add(employee);
                await _context.SaveChangesAsync();

                return "New employee is added successfully with employee id: " + employee.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }





        // update api
        public async Task UpdateEmployeeDetailsByIdAsync(int employeeId, EmployeeModel employeeModel)
        {


            try
            {
                var employee = new EmployeeTable()
                {
                    Id = employeeId,
                    EmpName = employeeModel.EmpName,
                    EmpPhone = employeeModel.EmpPhone,
                    EmpEmail = employeeModel.EmpEmail,
                    EmpAddress = employeeModel.EmpAddress
                };

                _context.EmployeeTable.Update(employee);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }

            //var employee = await _context.EmployeeTable.FindAsync(employeeId);
            //if(employee != null)
            //{
            //    employee.EmpName = employeeModel.EmpName;
            //    employee.EmpPhone = employeeModel.EmpPhone;
            //    employee.EmpEmail = employeeModel.EmpEmail;
            //    employee.EmpAddress = employeeModel.EmpAddress;

            //    await _context.SaveChangesAsync();
            //}

        }



        public async Task UpdateEmployeeByIdPatchAsync(int employeeId, JsonPatchDocument employeeModel)
        {
            try
            {
                var employee = await _context.EmployeeTable.FindAsync(employeeId);
                if (employee != null)
                {
                    employeeModel.ApplyTo(employee);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task DeleteEmployeeByIdAsync(int employeeId)
        {
            try
            {
                var employee = new EmployeeTable() { Id = employeeId };
                _context.EmployeeTable.Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }








    }
}
