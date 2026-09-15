using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Queries.DTOS
{
    public class GetEmployeeByIdDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Role { set; get; }
        public int ClinicId { set; get; }
    }
}
