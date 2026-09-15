using ClinicManagement.Application.Features.Prescriptions.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Prescriptions.Commands.Validators
{
    public class AddPrescriptionValidator : AbstractValidator<AddPrescriptionCommand>
    {
        public AddPrescriptionValidator()
        {
            RuleFor(x => x.AppointmentId)
                .GreaterThan(0)
                .WithMessage("Appointment Id must be greater than 0.");

            RuleFor(x => x.Details)
                .NotEmpty()
                .WithMessage("Prescription details are required.")
                .MaximumLength(1000)
                .WithMessage("Prescription details cannot exceed 1000 characters.");
        }
    }
}
