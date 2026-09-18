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
    public class LoginCommand : IRequest<Response<string>>
    {
        public LoginDTO LoginDTO { get; set; }

        public LoginCommand(LoginDTO  loginDTO)
        {
            LoginDTO = loginDTO;
        }
    }
}
