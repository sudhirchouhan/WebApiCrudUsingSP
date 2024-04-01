using FirstCruWebAPI.Models;
using FirstCruWebAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCruWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _empService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepo empService, ILogger<EmployeeController> logger)
        {
            _empService = empService;
            _logger = logger;
        }
        [HttpGet("getemployeelist")]
        public async Task<List<Employee>> GetEmployeeList()
        {
            try
            {
                
                _logger.LogInformation("Requesting Employee List Details...");
                return await _empService.GetEmployeeListAsync();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("getemployeebyid")]
        public async Task<IEnumerable<Employee>> GetEmployeeById(int Id)
        {
            try
            {
                _logger.LogInformation("Requesting Employee by Id...");
                var response = await _empService.GetEmployeeByIdAsync(Id);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
        [HttpPost("addemployee")]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            _logger.LogInformation("Requesting  to add Employee in DB...");
            if (emp == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await _empService.AddEmployeeAsync(emp);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut("updateemployee")]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _empService.UpdateEmployeeAsync(emp);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpDelete("deleteEmployee")]
        public async Task<int> DeleteEmployee(int Id)
        {
            try
            {
                var response = await _empService.DeleteEmployeeAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
