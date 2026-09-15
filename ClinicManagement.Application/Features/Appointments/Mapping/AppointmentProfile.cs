using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Command.Mapping
{
    public partial class AppointmentProfile:Profile
    {
        public AppointmentProfile()
        {
            GetAllAppointmentsMapping();
            BookAppointmentMapping();
            UpdateAppointmentMapping();
        }
    }
}
