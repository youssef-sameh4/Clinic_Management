using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Command.Models
{
    public  class DeleteAppointmentCommand:IRequest<Response<string>>
    {
        public int Id { set; get; }

        public DeleteAppointmentCommand(int id)
        {
            Id = id;
        }
    }
}
