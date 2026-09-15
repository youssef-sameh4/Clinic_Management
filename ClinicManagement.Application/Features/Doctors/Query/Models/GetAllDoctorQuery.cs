using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Doctors.Query.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Query.Models
{
    public  class GetAllDoctorQuery:IRequest<Response<List<GetAllDoctorDTO>>>
    {
    }
}
