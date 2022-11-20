using EmployeeManagementSystem_Tech.Models;
using EmployeeManagementSystem_Tech.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagementSystem_Tech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeeAsync();            
            return Ok(employees);

        }

        // employee by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeDetailsById([FromRoute]int id)
        {
            var employeeById = await _employeeRepository.GetEmployeeDetailsByIdAsync(id);
            if(employeeById == null)
            {
                return NotFound("No Records is availabe with id: "+id);
            }
            return Ok(employeeById);

        }


        // add new employee
        [HttpPost("")]
        public async Task<IActionResult> AddNewEmployee([FromBody]EmployeeModel employeeModel)
        {
            var id = await _employeeRepository.AddNewEmployeeAsync(employeeModel);
            return CreatedAtAction(nameof(GetEmployeeDetailsById), new { id = id, controller = "Employee" }, id);

        }


        // update employee details by id

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeById([FromBody] EmployeeModel employeeModel, [FromRoute]int id)
        {
            await _employeeRepository.UpdateEmployeeDetailsByIdAsync(id, employeeModel);
            return Ok();
        }



        // using patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmployeeByIdPatch([FromBody] JsonPatchDocument employeeModel, [FromRoute] int id)
        {
            await _employeeRepository.UpdateEmployeeByIdPatchAsync(id, employeeModel);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById([FromRoute] int id)
        {
            await _employeeRepository.DeleteEmployeeByIdAsync(id);
            return Ok();
        }



    }
}
