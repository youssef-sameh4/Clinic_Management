using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Auth.Commends.Models;
using ClinicManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Auth.Commends.Handlers
{
    public class AuthHandlers : ResponseHandler, IRequestHandler<LoginCommand, Response<string>>,
        IRequestHandler<RegisterCommand, Response<string>>
    {
        private readonly IAuthService _authService;

        public AuthHandlers(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Response<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
           return await _authService.LoginAsync(request.LoginDTO);
        }

        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterAsync(request.RegisterDTO);
        }
    }
}
