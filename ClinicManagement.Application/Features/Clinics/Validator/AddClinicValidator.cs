using ClinicManagement.Application.Features.Clinics.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Clinics.Validator
{
    public class AddClinicValidator : AbstractValidator<AddClinicCommand>
    {
        public AddClinicValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Clinic name is required.")
                .MaximumLength(100)
                .WithMessage("Clinic name must not exceed 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Clinic address is required.")
                .MaximumLength(200)
                .WithMessage("Clinic address must not exceed 200 characters.");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithMessage("Doctor Id must be greater than 0.");
        }
    }
}
