using ClinicManagement.Application.Features.Appointments.Command.Models;
using ClinicManagement.Application.Features.Appointments.Command.Payments;
using ClinicManagement.Application.Features.Appointments.Query.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Book Appointment")]
        public async Task<ActionResult> BookAppointment(BookAppointmentCommand bookAppointment)
        {

            var response = await _mediator.Send(bookAppointment);
            return Ok(response);
        }
        [HttpPost("Add Payment")]
        public async Task<ActionResult> AddPayment(PaymentCommand paymentCommand)
        {

            var response = await _mediator.Send(paymentCommand);
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAppointment()
        {

            var response = await _mediator.Send(new GetAllAppointmentsQuery());
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> BookAppointment(UpdateAppointmentCommand updateAppointment)
        {

            var response = await _mediator.Send(updateAppointment);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> BookAppointment(int Id)
        {

            var response = await _mediator.Send(new DeleteAppointmentCommand(Id));
            return Ok(response);
        }

    }
}
