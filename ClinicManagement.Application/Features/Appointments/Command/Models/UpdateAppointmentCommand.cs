using ClinicManagement.Application.Bases;
using ClinicManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Command.Models
{
    public class UpdateAppointmentCommand:IRequest<Response<string>>
    {
        public UpdateAppointmentCommand(int id, DateTime startTime, int doctorId, int patientId, int clinicId, SourceStatus source)
        {
            Id = id;
            StartTime = startTime;
            DoctorId = doctorId;
            PatientId = patientId;
            ClinicId = clinicId;
            Source = source;
        }

        public int Id { set; get; }
        public DateTime StartTime { set; get; }
        public int DoctorId { set; get; }
        public int PatientId { set; get; }
        public int ClinicId { set; get; }
        public SourceStatus Source { set; get; }
    }
}
