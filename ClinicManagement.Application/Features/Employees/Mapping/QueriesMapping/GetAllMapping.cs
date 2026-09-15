using ClinicManagement.Application.Features.Employees.Commands.Modles;
using ClinicManagement.Application.Features.Employees.Queries.DTOS;
using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Mapping
{
    public partial class EmployeeProfile
    {
        public void GetAllMapping()
        {
            CreateMap<Employee, GetAllEmployeesDTO>();

        }
    }
}
