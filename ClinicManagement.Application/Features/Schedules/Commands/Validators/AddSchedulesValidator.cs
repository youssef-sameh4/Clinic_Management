using ClinicManagement.Application.Features.Schedules.Commands.Modles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Schedules.Commands.Validators
{
    public class AddSchedulesValidator : AbstractValidator<AddSchedulesCommand>
    {
        public AddSchedulesValidator()
        {
            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithMessage("DoctorId must be greater than 0.");

            RuleFor(x => x.ClinicId)
                .GreaterThan(0)
                .WithMessage("ClinicId must be greater than 0.");

            RuleFor(x => x.StartTime)
                .NotEmpty()
                .WithMessage("Start time is required.");

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .WithMessage("End time is required.");

            RuleFor(x => x)
                .Must(x => x.EndTime > x.StartTime)
                .WithMessage("End time must be greater than start time.");
        }
    }
}
