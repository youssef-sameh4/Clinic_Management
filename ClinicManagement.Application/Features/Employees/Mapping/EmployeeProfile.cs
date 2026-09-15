using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Mapping
{
    public partial class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            AddEmployeeMapping();
            UpdateEmployeeMapping();
            GetAllMapping();
            GetByIdMapping();
        }
    }
}
