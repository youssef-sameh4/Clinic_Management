using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Appointments.Command.Models;
using ClinicManagement.Application.Features.Appointments.Validators;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using ClinicManagement.Domain.Enums;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Command.Handlers
{
    public class AppointmentHandler : ResponseHandler, IRequestHandler<BookAppointmentCommand, Response<string>>,
        IRequestHandler<UpdateAppointmentCommand, Response<string>>,
        IRequestHandler<DeleteAppointmentCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BookAppointmentValidator _bookAppointmentValidator;
        private readonly UpdateAppointmentValidator _updateAppointmentValidator;

        public AppointmentHandler(IUnitOfWork unitOfWork, IMapper mapper, BookAppointmentValidator bookAppointmentValidator, UpdateAppointmentValidator updateAppointmentValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookAppointmentValidator = bookAppointmentValidator;
            _updateAppointmentValidator = updateAppointmentValidator;
        }

        public async Task<Response<string>> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _bookAppointmentValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
                    ", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)
                );

                return BadRequest<string>(errors);
            }

            var expictedDoctor = await _unitOfWork.Doctors
                .GetByIdAsync(request.DoctorId);

            if (expictedDoctor == null)
            {
                return NotFound<string>("Doctor Not Found");
            }

            var expictedPatient = await _unitOfWork.Patients
                .GetByIdAsync(request.PatientId);

            if (expictedPatient == null)
            {
                return NotFound<string>("Patient Not Found");
            }

            var expictedClinic = await _unitOfWork.Clinics
                .GetByIdAsync(request.ClinicId);

            if (expictedClinic == null)
            {
                return NotFound<string>("Clinic Not Found");
            }

            if (expictedClinic.DoctorId != expictedDoctor.Id)
            {
                return BadRequest<string>(
                    "This Doctor is not assigned to this Clinic."
                );
            }

            var appointmentTime = TimeOnly.FromDateTime(request.StartTime);
            var appointmentDay = request.StartTime.DayOfWeek;

            var schedule = _unitOfWork.Schedules
                .GetTableNoTracking()
                .FirstOrDefault(s =>
                    s.DoctorId == expictedDoctor.Id &&
                    s.ClinicId == expictedClinic.Id &&
                    s.Day == appointmentDay &&
                    s.StartTime <= appointmentTime &&
                    s.EndTime > appointmentTime
                );

            if (schedule == null)
            {
                return BadRequest<string>(
                    "Doctor is not available at this time."
                );
            }

            var expictedAppointment = _unitOfWork.Appointments
                .GetTableNoTracking()
                .FirstOrDefault(a =>
                    a.DoctorId == expictedDoctor.Id &&
                    a.StartTime == request.StartTime
                );

            if (expictedAppointment != null)
            {
                return BadRequest<string>(
                    "This appointment slot is already booked."
                );
            }
            var appointmentMap = _mapper.Map<Appointment>(request);
            appointmentMap.Status = AppointmentStatus.Pending;
            appointmentMap.ConsultationFee = expictedDoctor.ConsultationFee;
            await _unitOfWork.Appointments.AddAsync(appointmentMap);
            await _unitOfWork.SaveChangesAsync();
            return Created("Appointments Created Successfully");

        }

        public async Task<Response<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _updateAppointmentValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
                    ", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)
                );

                return BadRequest<string>(errors);
            }
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.Id);
            if (appointment == null)
            {
                return NotFound<string>("Appointment Not Found");
            }
            _mapper.Map(request, appointment);
            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.SaveChangesAsync();
            return Success("Appointment Update Successfully");


        }

        public async Task<Response<string>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.Id);
            if (appointment == null)
            {
                return NotFound<string>("Appointment Not Found");
            }
            await _unitOfWork.Appointments.DeleteAsync(appointment);
            await _unitOfWork.SaveChangesAsync();
            return Deleted<string>("Appointment Deleted Successfully");
        }
    }
}
