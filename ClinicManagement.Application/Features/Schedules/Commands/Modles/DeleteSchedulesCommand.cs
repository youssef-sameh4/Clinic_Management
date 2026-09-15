using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Schedules.Commands.Modles
{
    public class DeleteSchedulesCommand:IRequest<Response<string>>
    {
        public int Id { set; get; }

        public DeleteSchedulesCommand(int id)
        {
            Id = id;
        }
    }
}
