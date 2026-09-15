using ClinicManagement.Application.Features.Appointments.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Validators
{
    public  class UpdateAppointmentValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithMessage("Doctor Id must be greater than 0.");
            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithMessage("Doctor Id must be greater than 0.");

            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.ClinicId)
                .GreaterThan(0)
                .WithMessage("Clinic Id must be greater than 0.");

            RuleFor(x => x.StartTime)
                .GreaterThan(DateTime.Now)
                .WithMessage("Appointment time must be in the future.");

            RuleFor(x => x.Source)
                .IsInEnum()
                .WithMessage("Invalid appointment source.");
        }

    }
}
