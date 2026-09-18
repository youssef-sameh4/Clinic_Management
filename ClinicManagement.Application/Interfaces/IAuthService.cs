using ClinicManagement.Application.Bases;
using ClinicManagement.Application.DTOs;
using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Response<string>> RegisterAsync(RegisterDTO registerDTO);
        Task<Response<string>> LoginAsync(LoginDTO loginDTO);

    }
}
