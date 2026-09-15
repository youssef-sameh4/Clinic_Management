using ClinicManagement.Application.Features.Clinics.Commands.Models;
using ClinicManagement.Application.Features.Clinics.Quearies.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClinicsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClinics()
        {
            var response = await _mediator.Send(new GetAllClinicQuery());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClinicById([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetClinicByIdQuery(Id));
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddClinic([FromBody] AddClinicCommand addClinic)
        {
            var response = await _mediator.Send(addClinic);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateClinic([FromBody] UpdateClinicCommand updateClinic)
        {
            var response = await _mediator.Send(updateClinic);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClinic([FromRoute] int Id)
        {
            var response = await _mediator.Send(new DeleteClinicCommand(Id));
            return Ok(response);
        }
    }
}
