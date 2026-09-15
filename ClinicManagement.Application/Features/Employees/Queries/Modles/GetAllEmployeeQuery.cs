using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Employees.Queries.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Queries.Modles
{
    public class GetAllEmployeeQuery:IRequest<Response<List<GetAllEmployeesDTO>>>
    {
    }
}
