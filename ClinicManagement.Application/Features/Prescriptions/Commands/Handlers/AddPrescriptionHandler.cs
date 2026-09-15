using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Prescriptions.Commands.Models;
using ClinicManagement.Application.Features.Prescriptions.Commands.Validators;
using ClinicManagement.Application.Features.Schedules.Commands.Validators;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using ClinicManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Prescriptions.Commands.Handlers
{
    public class AddPrescriptionHandler : ResponseHandler, IRequestHandler<AddPrescriptionCommand, Response<string>>,
        IRequestHandler<UpdatePrescriptionCommand, Response<string>>,
        IRequestHandler<DeletePrescriptionCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AddPrescriptionValidator _addPrescriptionValidator  ;

        public AddPrescriptionHandler(IUnitOfWork unitOfWork, IMapper mapper, AddPrescriptionValidator addPrescriptionValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _addPrescriptionValidator = addPrescriptionValidator;
        }

        public async Task<Response<string>> Handle(AddPrescriptionCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _addPrescriptionValidator.ValidateAsync(request);

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
            if (appointment.Status != AppointmentStatus.Booked)
            {
                return BadRequest<string>(
       "Prescription can only be added to a booked appointment."
   );
            }
            var prescriptionMap = _mapper.Map<Prescription>(request);
            prescriptionMap.Date = DateTime.Now;
            appointment.Status = AppointmentStatus.Completed;
            await _unitOfWork.Prescriptions.AddAsync(prescriptionMap);
            await _unitOfWork.SaveChangesAsync();
            return Created("Prescription Added Successfully ");

        }

        public async Task<Response<string>> Handle(UpdatePrescriptionCommand request, CancellationToken cancellationToken)
        {
            var prescroption = await _unitOfWork.Prescriptions.GetByIdAsync(request.Id);
            if (prescroption == null)
            {
                return NotFound<string>();
            }
            _mapper.Map(request, prescroption);
            await _unitOfWork.SaveChangesAsync();
            return Success("prescroption Updated Succefully");
        }

        public async Task<Response<string>> Handle(DeletePrescriptionCommand request, CancellationToken cancellationToken)
        {
            var prescroption = await _unitOfWork.Prescriptions.GetByIdAsync(request.Id);
            if (prescroption == null)
            {
                return NotFound<string>();
            }
            await _unitOfWork.Prescriptions.DeleteAsync(prescroption);
            await _unitOfWork.SaveChangesAsync();
            return Deleted<string>("prescroption Deleted Succefully");
        }
    }
}
