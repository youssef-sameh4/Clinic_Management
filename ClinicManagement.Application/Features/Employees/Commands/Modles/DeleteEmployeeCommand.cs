using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Commands.Modles
{
    public class DeleteEmployeeCommand: IRequest<Response<string>>
    {
        public int Id { set; get; }

        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
