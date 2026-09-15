using ClinicManagement.Application.Bases;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Schedules.Commands.Modles
{
    public class AddSchedulesCommand:IRequest<Response<string>>
    {
        public AddSchedulesCommand(int doctorId, int clinicId, DayOfWeek day, TimeOnly startTime, TimeOnly endTime)
        {
            DoctorId = doctorId;
            ClinicId = clinicId;
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int DoctorId { get; set; }

        public int ClinicId { get; set; }
        public DayOfWeek Day { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
