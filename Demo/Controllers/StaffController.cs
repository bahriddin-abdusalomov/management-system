using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaffAsync(StaffDtos staff)
        {
            await staffRepository.CreateStaffAsync(staff);
            return Ok("Created");
        }
       
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await staffRepository.GetAllAsync();

            return Ok(res);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteStaffAsync(Guid staffId)
        {
            await staffRepository.DeleteStaff(staffId);

            return Ok("Deleted");
        }
        
        [HttpGet("GetAllEmplyeesByStaffId")]
        public async Task<IActionResult> GetAllEmplyeesByStaffId(Guid staffId)
        {
            var res = await staffRepository.GetAllEmplyeesByStaffId(staffId);

            return Ok(res);
        }
        
        [HttpPost("AddEmployeeToStaff")]
        public async Task<IActionResult> AddEmployeeToStaff(Guid staffId, List<Guid> employee)
        {   
            await staffRepository.AddEmployeesToStaff(staffId,employee);

            return Ok("Added");
        }
    }
}