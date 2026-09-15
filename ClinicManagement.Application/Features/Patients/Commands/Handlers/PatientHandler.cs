using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Patients.Commands.Models;
using ClinicManagement.Application.Features.Patients.Commands.Validators;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Commands.Handlers
{
    public class PatientHandler : ResponseHandler, IRequestHandler<AddPatientCommand, Response<string>>,
        IRequestHandler<UpdatePatientCommand, Response<string>>,
        IRequestHandler<DeletePatientCommand, Response<string>>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AddPatientValidator _addPatientValidator;
        private readonly UpdatePatientValidator _updatePatientValidator;

        public PatientHandler(IUnitOfWork unitOfWork, IMapper mapper, AddPatientValidator addPatientValidator, UpdatePatientValidator updatePatientValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _addPatientValidator = addPatientValidator;
            _updatePatientValidator = updatePatientValidator;
        }

        public async Task<Response<string>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _addPatientValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
                    ", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)
                );

                return BadRequest<string>(errors);
            }
            var patientMap = _mapper.Map<Patient>(request);
            await _unitOfWork.Patients.AddAsync(patientMap);
            await _unitOfWork.Patients.SaveChangesAsync();
            return Created("Patient Created Successfully");
        }

        public async Task<Response<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _updatePatientValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
                    ", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)
                );

                return BadRequest<string>(errors);
            }

            var patient = await _unitOfWork.Patients.GetByIdAsync(request.Id);

            if (patient == null)
            {
                return NotFound<string>("Patient Not Found");
            }

            patient.Name = request.Name;
            patient.Address = request.Address;
            patient.Gender = request.Gender;
            patient.DateOfBirth = request.DateOfBirth;
            patient.Phone = request.Phone;
            patient.Email = request.Email;

            await _unitOfWork.Patients.UpdateAsync(patient);
            await _unitOfWork.SaveChangesAsync();

            return Success("Patient Updated Successfully");
        }

        

        public async Task<Response<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.Id);
            if (patient == null)
            {

            }
            await _unitOfWork.Patients.DeleteAsync(patient);
            await _unitOfWork.Patients.SaveChangesAsync();
            return Deleted<string>("patient Deleted Successfully");


        }
    }
}
