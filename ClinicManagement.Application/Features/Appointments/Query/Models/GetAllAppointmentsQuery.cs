using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Appointments.Query.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Query.Models
{
    public class GetAllAppointmentsQuery:IRequest<Response<List<GetAllAppointmentsDTO>>>
    {
    }
}
