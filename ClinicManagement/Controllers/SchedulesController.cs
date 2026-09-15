using ClinicManagement.Application.Features.Schedules.Commands.Modles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> AddSchedule(AddSchedulesCommand addSchedules)
        {
            var response =await _mediator.Send(addSchedules);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateSchedule(UpdateSchedulesCommand updateSchedules)
        {
            var response = await _mediator.Send(updateSchedules);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteSchedule(int Id )
        {
            var response = await _mediator.Send(new DeleteSchedulesCommand(Id));
            return Ok(response);
        }

    }
}
