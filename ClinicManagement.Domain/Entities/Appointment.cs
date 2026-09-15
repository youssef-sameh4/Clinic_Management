using ClinicManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
        public  class Appointment
        {
            public int Id { set; get; }
            public DateTime StartTime { set; get; }
            public int DoctorId { set; get; }
            public Doctor Doctor { set; get; }
            public int  PatientId{ set; get; }
            public Patient Patient { set; get; }
            public int ClinicId { set; get; }
            public Clinic Clinic { set; get; }
              public AppointmentStatus Status{ set; get; }
            public SourceStatus Source { set; get; }
            public Prescription Prescription { get; set; }
            public decimal ConsultationFee { set; get; }
            public int QueueNumber { set; get; }
        }
}
