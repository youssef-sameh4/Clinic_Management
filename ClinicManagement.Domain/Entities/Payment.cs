using ClinicManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Payment
    {
        public int Id { set; get; }
        public decimal Amount { set; get; }
        public int AppointmentId{set;get;}
        public Appointment Appointment { set; get; }
        public PaymentMethodStatus PaymentMethod { set; get; }
        public PaymentStatus Status { set; get; } 
    }
}
