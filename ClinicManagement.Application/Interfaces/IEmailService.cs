using ClinicManagement.Application.Common.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAppointmentConfirmationAsync(EmailMessageDTO message);
    }
}
