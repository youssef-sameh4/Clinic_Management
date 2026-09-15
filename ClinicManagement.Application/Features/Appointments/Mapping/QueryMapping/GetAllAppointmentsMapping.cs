using ClinicManagement.Application.Features.Appointments.Query.DTOS;
using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Command.Mapping
{
    public partial class AppointmentProfile
    {
        public void GetAllAppointmentsMapping()
        {
            CreateMap<Appointment, GetAllAppointmentsDTO>();
        }
    }
}
