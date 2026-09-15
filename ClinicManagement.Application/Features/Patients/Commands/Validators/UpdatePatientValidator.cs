using ClinicManagement.Application.Features.Patients.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Commands.Validators
{
    public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Patient name is required.")
                .MaximumLength(100)
                .WithMessage("Patient name must not exceed 100 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.");

            RuleFor(x => x.Gender)
                .NotEmpty()
                .WithMessage("Gender is required.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .MaximumLength(200)
                .WithMessage("Address must not exceed 200 characters.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Invalid email address.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now)
                .WithMessage("Date of birth must be in the past.");
        }
    }
}
