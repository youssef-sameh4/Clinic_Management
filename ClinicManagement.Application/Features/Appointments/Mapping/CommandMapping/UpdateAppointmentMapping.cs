using ClinicManagement.Application.Features.Appointments.Command.Models;
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
        public void UpdateAppointmentMapping()
        {
            CreateMap<UpdateAppointmentCommand, Appointment>();
        }
    }
}
