using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Clinics.Commands.Models
{
    public class DeleteClinicCommand: IRequest<Response<string>>
    {
        public int Id { set; get; }

        public DeleteClinicCommand(int id)
        {
            Id = id;
        }
    }
}
