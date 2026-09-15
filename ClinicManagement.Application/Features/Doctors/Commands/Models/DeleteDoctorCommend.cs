using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Commands.Models
{
    public class DeleteDoctorCommend:IRequest<Response<string>>
    {
        public int Id { set; get; }

        public DeleteDoctorCommend(int id)
        {
            Id = id;
        }
    }
}
