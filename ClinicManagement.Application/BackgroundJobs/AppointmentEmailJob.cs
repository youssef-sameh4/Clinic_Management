using ClinicManagement.Application.Common.Email;
using ClinicManagement.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Application.BackgroundJobs
{
    public class AppointmentEmailJob
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public AppointmentEmailJob(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }
        public async Task ExecuteAsync(int appointmentId)
        {
            var appointment = await _unitOfWork.Appointments
                .GetTableNoTracking()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Clinic)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);

            if (appointment == null)
                return;

            var payment = await _unitOfWork.Payments
                .GetTableNoTracking()
                .FirstOrDefaultAsync(p => p.AppointmentId == appointmentId);

            if (payment == null)
                return;

            var emailMessage = new EmailMessageDTO
            {
                PatientName = appointment.Patient.Name,
                PatientEmail = appointment.Patient.Email,

                DoctorName = appointment.Doctor.Name,
                ClinicName = appointment.Clinic.Name,

                AppointmentDateTime = appointment.StartTime,

                QueueNumber = appointment.QueueNumber,

                ConsultationFee = appointment.ConsultationFee,

                PaymentStatus = payment.Status
            };

            await _emailService.SendAppointmentConfirmationAsync(emailMessage);
        }
    }
}
