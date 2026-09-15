using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Clinics.Quearies.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Clinics.Quearies.Models
{
    public class GetClinicByIdQuery : IRequest<Response<GetClinicByIdDTO>>
    {
        public int Id { set; get; }

        public GetClinicByIdQuery(int id)
        {
            Id = id;
        }
    }
}
