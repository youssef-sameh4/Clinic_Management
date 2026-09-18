using AutoMapper;
using ClinicManagement.Application.BackgroundJobs;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Appointments.Validators;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using ClinicManagement.Domain.Enums;
using Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Command.Payments.Hnadlers
{
    public class PaymentHandler : ResponseHandler, IRequestHandler<PaymentCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PaymentValidator _paymentValidator;

        public PaymentHandler(IUnitOfWork unitOfWork, IMapper mapper, PaymentValidator paymentValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paymentValidator = paymentValidator;
        }

        public async Task<Response<string>> Handle(PaymentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _paymentValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
                    ", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)
                );

                return BadRequest<string>(errors);
            }
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);
            if (appointment == null)
            {
                return NotFound<string>("Appointment Not Found");
            }

           

            if (appointment.Status != AppointmentStatus.Pending)
            {
                return BadRequest<string>(
    "This appointment is not available for payment."
);
            }
            await _unitOfWork.BeginTransactionAsync(IsolationLevel.Serializable);

            try
            {
                var appointmentMaxqueueNum = _unitOfWork.Appointments
     .GetTableNoTracking()
     .Where(a =>
         a.ClinicId == appointment.ClinicId &&
         a.StartTime.Date == appointment.StartTime.Date)
     .Select(a => (int?)a.QueueNumber)
     .Max() ?? 0;

                var paymentMap = _mapper.Map<Payment>(request);

                paymentMap.Amount = appointment.ConsultationFee;
                paymentMap.Status = PaymentStatus.Paid;

                await _unitOfWork.Payments.AddAsync(paymentMap);

                appointment.Status = AppointmentStatus.Booked;

                if (appointmentMaxqueueNum == 0)
                {
                    appointment.QueueNumber = 1;
                }
                else
                {
                    appointment.QueueNumber = appointmentMaxqueueNum + 1;
                }

                await _unitOfWork.Appointments.UpdateAsync(appointment);

                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();
                BackgroundJob.Enqueue<AppointmentEmailJob>(
    job => job.ExecuteAsync(appointment.Id));

                return Success("Payment completed successfully.");
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();

                return BadRequest<string>("Payment failed.");
            }
        }
    }
}
