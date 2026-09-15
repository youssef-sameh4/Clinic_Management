using ClinicManagement.Application.Features.Schedules.Commands.Modles;
using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicManagement.Application.Features.Schedules.Mapping
{
    public partial class ScheduleProfile  
    {
    public void UpdateScheduleMapping()
    {
            CreateMap<UpdateSchedulesCommand, Schedule>();
        }
    }
}
