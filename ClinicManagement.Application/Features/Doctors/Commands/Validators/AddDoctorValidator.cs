using ClinicManagement.Application.Features.Doctors.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Commands.NewFolder
{
    public class AddDoctorValidator: AbstractValidator<AddDoctorCommand>
    {
        public AddDoctorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Doctor name is required.")
                .MaximumLength(100)
                .WithMessage("Doctor name must not exceed 100 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.");

            RuleFor(x => x.Specialization)
                .NotEmpty()
                .WithMessage("Specialization is required.")
                .MaximumLength(100)
                .WithMessage("Specialization must not exceed 100 characters.");

            RuleFor(x => x.ConsultationFee)
                .GreaterThan(0)
                .WithMessage("Consultation fee must be greater than 0.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters.");
        }
    }
}
