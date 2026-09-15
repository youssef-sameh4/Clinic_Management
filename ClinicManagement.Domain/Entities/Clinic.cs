using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public  class Clinic
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public int DoctorId { set; get; }
        public Doctor Doctor { set; get; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Employee>  Employees { get; set; }

    }
}
