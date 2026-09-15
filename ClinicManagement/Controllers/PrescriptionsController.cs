using ClinicManagement.Application.Features.Prescriptions.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddPrescription(AddPrescriptionCommand prescriptionCommand)
        {
            var response = await _mediator.Send(prescriptionCommand);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePrescription(UpdatePrescriptionCommand prescriptionCommand)
        {
            var response = await _mediator.Send(prescriptionCommand);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePrescription( [FromRoute]int Id)
        {
            var response = await _mediator.Send(new DeletePrescriptionCommand(Id));
            return Ok(response);
        }

    }
}
