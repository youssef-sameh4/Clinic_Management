using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Schedules.Commands.Modles
{
    public class UpdateSchedulesCommand:IRequest<Response<string>>
    {
        public UpdateSchedulesCommand(int id, int doctorId, int clinicId, DayOfWeek day, TimeOnly startTime, TimeOnly endTime)
        {
            Id = id;
            DoctorId = doctorId;
            ClinicId = clinicId;
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int Id { set; get; }
        public int DoctorId { get; set; }

        public int ClinicId { get; set; }
        public DayOfWeek Day { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
