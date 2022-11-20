using EmployeeManagementSystem_Tech.Models;
using EmployeeManagementSystem_Tech.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Tech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHourController : ControllerBase
    {
        private readonly IWorkingHourRepository _workingHourRepository;

        public WorkingHourController(IWorkingHourRepository workingHourRepository)
        {
            _workingHourRepository = workingHourRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllWorkingHour()
        {
            var wh = await _workingHourRepository.GetAllWorkingHourRecordsAsync();
            return Ok(wh);
        }


        // working hour details by sno
        [HttpGet("{sno}")]
        public async Task<IActionResult> GetWorkingHourDetailsByNo([FromRoute] int sno)
        {
            var whByno = await _workingHourRepository.GetWorkingHourDetailsByIdAsync(sno);
            if (whByno == null)
            {
                return NotFound("No Records is availabe with id: " + sno);
            }
            return Ok(whByno);

        }


        // add new workinghour
        [HttpPost("")]
        public async Task<IActionResult> AddNewWorkingHour([FromBody] WorkingHourModel workingHourModel)
        {
            var id = await _workingHourRepository.AddNewWorkingHourAsync(workingHourModel);

            return Ok(id);

        }

        // update WorkingHourDetailsByNo

        [HttpPut("{sno}")]
        public async Task<IActionResult> UpdateWorkingHourDetailsByNo([FromBody] WorkingHourModel workingHourModel, [FromRoute] int sno)
        {
            await _workingHourRepository.UpdateWorkingHourByNoAsync(sno, workingHourModel);
            return Ok();
        }


        //delete WorkingHour
        [HttpDelete("{sno}")]
        public async Task<IActionResult> DeleteWorkingHourByNo([FromRoute] int sno)
        {
            await _workingHourRepository.DeleteWorkingHourByNoAsync(sno);
            return Ok();
        }



    }
}
