using ClinicManagement.Application.Features.Appointments.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Command.Payments
{
    public class PaymentValidator : AbstractValidator<PaymentCommand>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.AppointmentId)
                .GreaterThan(0)
                .WithMessage("Appointment Id must be greater than 0.");

            RuleFor(x => x.PaymentMethod)
                .IsInEnum()
                .WithMessage("Invalid payment method.");
        }
    }
}
