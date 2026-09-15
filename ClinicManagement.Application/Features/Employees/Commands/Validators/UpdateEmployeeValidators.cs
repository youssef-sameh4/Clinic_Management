using ClinicManagement.Application.Features.Employees.Commands.Modles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Commands.Validators
{
    public class UpdateEmployeeValidators: AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidators()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Employee Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Employee name is required.")
                .MaximumLength(100)
                .WithMessage("Employee name cannot exceed 100 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .MaximumLength(20)
                .WithMessage("Phone number cannot exceed 20 characters.");

            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage("Employee role is required.")
                .MaximumLength(50)
                .WithMessage("Employee role cannot exceed 50 characters.");

            RuleFor(x => x.ClinicId)
                .GreaterThan(0)
                .WithMessage("ClinicId must be greater than 0.");
        }
    }
}
