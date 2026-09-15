using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Prescription
    {
        public int Id { set; get; }
        public int AppointmentId { set; get; }
        public Appointment Appointment { set; get; }
        public DateTime Date { set; get; }
        public string Details { set; get; }

    }
}
