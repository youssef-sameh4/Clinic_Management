using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Schedules.Mapping
{
    public partial class ScheduleProfile:Profile
    {
        public ScheduleProfile()
        {
            AddScheduleMapping();
            UpdateScheduleMapping();
        }
    }
}
