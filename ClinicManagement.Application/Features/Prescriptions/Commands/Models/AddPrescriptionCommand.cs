using ClinicManagement.Application.Bases;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Prescriptions.Commands.Models
{
    public class AddPrescriptionCommand:IRequest<Response<string>>
    {
        public AddPrescriptionCommand(int appointmentId,  string details)
        {
            AppointmentId = appointmentId;
            Details = details;
        }

        public int AppointmentId { set; get; }
        public string Details { set; get; }
    }
}
