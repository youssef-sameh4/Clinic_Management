using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Commands.Models
{
    public class DeletePatientCommand:IRequest<Response<string>>
    {
        public int Id { set; get; }

        public DeletePatientCommand(int id)
        {
            Id = id;
        }
    }
}
