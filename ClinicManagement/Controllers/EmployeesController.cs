using ClinicManagement.Application.Features.Employees.Commands.Modles;
using ClinicManagement.Application.Features.Employees.Queries.Modles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var response = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var response = await _mediator.Send(new GetEmployeeByIdQuery(Id));
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeCommand addEmployee)
        {
            var response =await  _mediator.Send(addEmployee);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommand updateEmployee)
        {
            var response = await _mediator.Send(updateEmployee);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteeEmployee(int Id)
        {
            var response = await _mediator.Send(new DeleteEmployeeCommand(Id));
            return Ok(response);
        }



    }
}
