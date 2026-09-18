using ClinicManagement.Application.Common.Email;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Infrastructure.Email;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendAppointmentConfirmationAsync(EmailMessageDTO message)
        {
            var email = new MimeMessage();

            email.From.Add(
                new MailboxAddress("Clinic Management", _emailSettings.From));

            email.To.Add(
                MailboxAddress.Parse(message.PatientEmail));

            email.Subject = "Appointment Confirmation";

            email.Body = new TextPart("plain")
            {
                Text = $"""
            Hello {message.PatientName},

            Your appointment has been confirmed successfully.

            Doctor: {message.DoctorName}
            Clinic: {message.ClinicName}
            Date: {message.AppointmentDateTime:dd/MM/yyyy}
            Time: {message.AppointmentDateTime:hh:mm tt}
            Queue Number: {message.QueueNumber}
            Consultation Fee: {message.ConsultationFee} EGP
            Payment Status: {message.PaymentStatus}

            Thank you,
            Clinic Management
            """
            };

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                _emailSettings.Host,
                _emailSettings.Port,
                MailKit.Security.SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                _emailSettings.Username,
                _emailSettings.Password);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    
}
}
