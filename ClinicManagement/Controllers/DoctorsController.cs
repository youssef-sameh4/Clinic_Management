using ClinicManagement.Application.Features.Doctors.Commands.Models;
using ClinicManagement.Application.Features.Doctors.Query.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var response = await _mediator.Send(new GetAllDoctorQuery());
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody]AddDoctorCommand doctorCommand)
        {
            var response = await _mediator.Send(doctorCommand);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor([FromBody]UpdateDoctorCommend doctorCommand)
        {
            var response = await _mediator.Send(doctorCommand);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDoctor ([FromRoute] int Id)
        {
            var response = await _mediator.Send(new DeleteDoctorCommend(Id));
            return Ok(response);
        }



    }
}
