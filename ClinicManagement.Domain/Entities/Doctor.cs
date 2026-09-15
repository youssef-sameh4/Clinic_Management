using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public  class Doctor
    {
        public int Id { set; get; }
        public string  Name { set; get; }
        public string Phone { set; get; }
        public string Specialization { set; get; }
        public decimal ConsultationFee { set; get; }
        public string Description { set; get; }
        public ICollection<Clinic> Clinics { set; get; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
