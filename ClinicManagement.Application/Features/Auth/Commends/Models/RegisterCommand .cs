using ClinicManagement.Application.Bases;
using ClinicManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Auth.Commends.Models
{
    public class RegisterCommand:IRequest<Response<string>>
    {
        public RegisterDTO RegisterDTO { get; set; }

        public RegisterCommand(RegisterDTO registerDTO)
        {
            RegisterDTO = registerDTO;
        }
    }
}
