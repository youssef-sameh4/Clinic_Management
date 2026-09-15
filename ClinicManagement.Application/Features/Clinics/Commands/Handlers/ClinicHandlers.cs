using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Clinics.Commands.Models;
using ClinicManagement.Application.Features.Clinics.Quearies.DTOS;
using ClinicManagement.Application.Features.Clinics.Validator;
using ClinicManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicEntity = ClinicManagement.Domain.Entities.Clinic;
namespace ClinicManagement.Application.Features.Clinics.Commands.Handlers
{
    public class ClinicHandlers : ResponseHandler, IRequestHandler<AddClinicCommand, Response<string>>,
        IRequestHandler<UpdateClinicCommand, Response<string>>,
        IRequestHandler<DeleteClinicCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AddClinicValidator _addClinicValidator;
        private readonly UpdateClinicValidator _updateClinicValidator;

        public ClinicHandlers(IUnitOfWork unitOfWork, IMapper mapper, AddClinicValidator addClinicValidator, UpdateClinicValidator updateClinicValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _addClinicValidator = addClinicValidator;
            _updateClinicValidator = updateClinicValidator;
        }

        public async Task<Response<string>> Handle(AddClinicCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _addClinicValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
                    ", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)
                );

                return BadRequest<string>(errors);
            }
            var clinicMap = _mapper.Map<ClinicEntity>(request);
          await _unitOfWork.Clinics.AddAsync(clinicMap);
            await _unitOfWork.Clinics.SaveChangesAsync();
             return Created<string>("Clinic added successfully");
        }

        public async Task<Response<string>> Handle(UpdateClinicCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _updateClinicValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
                    ", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)
                );

                return BadRequest<string>(errors);
            }
            var clinic = await _unitOfWork.Clinics.GetByIdAsync(request.Id);
            if (clinic == null)
            {
                return NotFound<string>("clinic Not Found");
            }
            clinic.Id = request.Id;
            clinic.Name = request.Name;
            clinic.Address = request.Address;
            clinic.DoctorId = request.DoctorId;
            await _unitOfWork.Clinics.UpdateAsync(clinic);
            await _unitOfWork.Clinics.SaveChangesAsync();
            return Success("Clinic Update successfully");


        }

        public async Task<Response<string>> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = await _unitOfWork.Clinics.GetByIdAsync(request.Id);
            if (clinic == null)
            {
                return NotFound<string>("clinic Not Found");
            }
            await _unitOfWork.Clinics.DeleteAsync(clinic);
            await _unitOfWork.Clinics.SaveChangesAsync();
            return Deleted<string>("Clinic Deleted successfully");

        }
    }
}