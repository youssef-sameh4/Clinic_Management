using ClinicManagement.Application.Bases;
using ClinicManagement.Domain.Entities;
using ClinicManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Command.Payments
{
    public class PaymentCommand:IRequest<Response<string>>
    {
        public PaymentCommand(int appointmentId, PaymentMethodStatus paymentMethod)
        {
            AppointmentId = appointmentId;
            PaymentMethod = paymentMethod;
        }

        public int AppointmentId { set; get; }
        public PaymentMethodStatus PaymentMethod { set; get; }
    }
}
