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
    public class GetAllClinicQuery:IRequest<Response<List<GetAllClinicDTO>>>
    {
    }
}
