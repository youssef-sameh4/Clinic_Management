using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Prescriptions.Commands.Models
{
    public class UpdatePrescriptionCommand : IRequest<Response<string>>
    {
        public UpdatePrescriptionCommand(int appointmentId, string details, int id)
        {
            AppointmentId = appointmentId;
            Details = details;
            Id = id;
        }
        public int Id { set; get; }
        public int AppointmentId { set; get; }
        public string Details { set; get; }
    }
}
