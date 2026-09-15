using ClinicManagement.Application.Features.Patients.Commands.Models;
using ClinicManagement.Application.Features.Patients.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await _mediator.Send(new GetAllPatientsQuery());
            return Ok(response);

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPatientById([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetPatientByIdQuery(Id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] AddPatientCommand addPatientCommand)
        {
            var response = await _mediator.Send(addPatientCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientCommand updatePatientCommand)
        {
            var response = await _mediator.Send(updatePatientCommand);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int Id)
        {
            var response = await _mediator.Send(new DeletePatientCommand(Id));
            return Ok(response);
        }
    }
}
