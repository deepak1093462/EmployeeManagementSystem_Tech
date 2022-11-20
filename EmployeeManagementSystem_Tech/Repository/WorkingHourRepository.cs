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
    public class WorkingHourRepository : IWorkingHourRepository
    {
        private readonly EmpManagSystemContext _context;

        public WorkingHourRepository(EmpManagSystemContext context)
        {
            _context = context;
        }


        // Get all Working hour records 
        public async Task<List<WorkingHourModel>> GetAllWorkingHourRecordsAsync()
        {
            try
            {
                var records = await _context.WorkingHourTable.Select(x => new WorkingHourModel()
                {
                    SNo = x.SNo,
                    Month = x.Month,
                    CompanyWorkingHour = x.CompanyWorkingHour,
                    EmployeeWorkingHour = x.EmployeeWorkingHour
                }).ToListAsync();

                return records;
            }
            catch (Exception)
            {
                throw;
            }



            
            
        }


        // get working hour details by no
        public async Task<WorkingHourModel> GetWorkingHourDetailsByIdAsync(int whsno)
        {
            try
            {
                var records = await _context.WorkingHourTable.Where(x => x.SNo == whsno).Select(x => new WorkingHourModel()
                {
                    SNo = x.SNo,
                    Month = x.Month,
                    CompanyWorkingHour = x.CompanyWorkingHour,
                    EmployeeWorkingHour = x.EmployeeWorkingHour
                }).FirstOrDefaultAsync();

                return records;
            }
            catch (Exception)
            {
                throw;
            }



            

        }


        


        // add new AddNewWorkingHour
        public async Task<string> AddNewWorkingHourAsync(WorkingHourModel workingHourModel)
        {
            try
            {
                var newWh = new WorkingHourTable()
                {
                    Month = workingHourModel.Month,
                    CompanyWorkingHour = workingHourModel.CompanyWorkingHour,
                    EmployeeWorkingHour = workingHourModel.EmployeeWorkingHour
                };



                _context.WorkingHourTable.Add(newWh);
                await _context.SaveChangesAsync();

                return "New working hour is added successfully with serial no: " + newWh.SNo;
            }
            catch (Exception)
            {
                throw;
            }



            
        }





        // update api
        public async Task UpdateWorkingHourByNoAsync(int whno, WorkingHourModel workingHourModel)
        {

            try
            {
                var whObj = new WorkingHourTable()
                {
                    SNo = whno,
                    Month = workingHourModel.Month,
                    CompanyWorkingHour = workingHourModel.CompanyWorkingHour,
                    EmployeeWorkingHour = workingHourModel.EmployeeWorkingHour
                };

                _context.WorkingHourTable.Update(whObj);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }





                     

        }        



        // delete working hour by sno
        public async Task DeleteWorkingHourByNoAsync(int whno)
        {


            try
            {
                var whobj = new WorkingHourTable() { SNo = whno };
                _context.WorkingHourTable.Remove(whobj);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }



            
        }








    }
}
