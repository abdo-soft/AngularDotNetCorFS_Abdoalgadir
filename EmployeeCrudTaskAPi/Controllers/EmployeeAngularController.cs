using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmployeeCrudTaskAPi.Models;
using EmployeeCrudTaskAPi.Repository;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeCrudTaskAPi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAngularController : ControllerBase
    {
        private readonly IEmployeeAngularRepository _employee;
       

        public EmployeeAngularController(IEmployeeAngularRepository employee)
        {
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
           
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employee.GetEmployees());
        }

        [HttpGet]
        [Route("GetEmployeeByID/{Id}")]
        public async Task<IActionResult> GetEmpByID(int Id)
        {
            return Ok(await _employee.GetEmployeeByID(Id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post(EmployeeAngular emp)
        {
            var result = await _employee.InsertEmployee(emp);
            if (result.EmployeeID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }


        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put(EmployeeAngular emp)
        {
            await _employee.UpdateEmployee(emp);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _employee.DeleteEmployee(id);
            return new JsonResult("Deleted Successfully");
        }

       
    }
}
