using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Commands.Modles
{
    public class UpdateEmployeeCommand : IRequest<Response<string>>
    {
        public UpdateEmployeeCommand(string name, string phone, string role, int clinicId, int id)
        {
            Name = name;
            Phone = phone;
            Role = role;
            ClinicId = clinicId;
            Id = id;
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Role { set; get; }
        public int ClinicId { set; get; }
    }
}
