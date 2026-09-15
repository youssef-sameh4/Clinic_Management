using ClinicManagement.Domain.Entities;
using ClinicManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Query.DTOS
{
    public class GetAllAppointmentsDTO
    {
        public int Id { set; get; }
        public DateTime StartTime { set; get; }
        public int DoctorId { set; get; }
        public int PatientId { set; get; }
        public int ClinicId { set; get; }
        public AppointmentStatus Status { set; get; }
        public SourceStatus Source { set; get; }
        public decimal ConsultationFee { set; get; }
    }
}
