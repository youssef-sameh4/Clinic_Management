using ClinicManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Common.Email
{
    public class EmailMessageDTO
    {
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }

        public string DoctorName { get; set; }
        public string ClinicName { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public int QueueNumber { get; set; }

        public decimal ConsultationFee { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
