using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Patients.Queries.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Queries.Models
{
    public class GetAllPatientsQuery:IRequest<Response<List<GetAllPatientsDTO>>>
    {
    }
}
