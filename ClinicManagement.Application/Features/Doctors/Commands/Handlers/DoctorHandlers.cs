using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Doctors.Commands.Models;
using ClinicManagement.Application.Features.Doctors.Commands.NewFolder;
using ClinicManagement.Application.Features.Doctors.Commands.Validators;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Commands.Hndlers
{
    public class DoctorHandlers : ResponseHandler, IRequestHandler<AddDoctorCommand, Response<string>>,
        IRequestHandler<UpdateDoctorCommend, Response<string>>,
        IRequestHandler<DeleteDoctorCommend, Response<string>>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AddDoctorValidator _validator;
        private readonly UpdateDoctorValidator _updatevalidator;
        public DoctorHandlers(IUnitOfWork unitOfWork, IMapper mapper, AddDoctorValidator validationRules, UpdateDoctorValidator updatevalidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validationRules;
            _updatevalidator = updatevalidator;
        }

        public async Task<Response<string>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
           ", ",
           validationResult.Errors.Select(x => x.ErrorMessage)
       );

                return BadRequest<string>(errors);
            }
            var doctor = _mapper.Map<Doctor>(request);
            await _unitOfWork.Doctors.AddAsync(doctor);
            await _unitOfWork.SaveChangesAsync();
            return Created("Doctor Created Successfuly");

        }

        public async Task<Response<string>> Handle(UpdateDoctorCommend request, CancellationToken cancellationToken)
        {
            var validationResult = await _updatevalidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
           ", ",
           validationResult.Errors.Select(x => x.ErrorMessage)
       );

                return BadRequest<string>(errors);
            }

            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.Id);

            if (doctor == null)
            {
                return NotFound<string>("Doctor Not Found");
            }
            doctor.Name = request.Name;
            doctor.Phone = request.Phone;
            doctor.Specialization = request.Specialization;
            doctor.ConsultationFee = request.ConsultationFee;
            doctor.Description = request.Description;
            await  _unitOfWork.Doctors.UpdateAsync(doctor);
            await _unitOfWork.SaveChangesAsync();
            return Success("Doctor Update Successfuly");
        }

        public async Task<Response<string>> Handle(DeleteDoctorCommend request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.Id);

            if (doctor == null)
            {
                return NotFound<string>("Doctor Not Found");
            }
            await _unitOfWork.Doctors.DeleteAsync(doctor);
            await _unitOfWork.Doctors.SaveChangesAsync();
            return Deleted<string>("Doctor Deleted Successfuly");

        }
    }
}
