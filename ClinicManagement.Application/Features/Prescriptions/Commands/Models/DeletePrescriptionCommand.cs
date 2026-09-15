using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Prescriptions.Commands.Models
{
    public  class DeletePrescriptionCommand:IRequest<Response<string>>
    {
        public int Id { set; get; }

        public DeletePrescriptionCommand(int id)
        {
            Id = id;
        }
    }
}
