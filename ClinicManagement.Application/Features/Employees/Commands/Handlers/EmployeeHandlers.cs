using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Employees.Commands.Modles;
using ClinicManagement.Application.Features.Employees.Commands.Validators;
using ClinicManagement.Application.Features.Employees.Queries.DTOS;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Commands.Handlers
{
    public class EmployeeHandlers : ResponseHandler, IRequestHandler<AddEmployeeCommand, Response<string>>,
        IRequestHandler<DeleteEmployeeCommand, Response<string>>,
        IRequestHandler<UpdateEmployeeCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AddEmployeeValidators _addValidator;
        private readonly UpdateEmployeeValidators _updatevalidator;

        public EmployeeHandlers(IUnitOfWork unitOfWork, IMapper mapper, AddEmployeeValidators addValidator, UpdateEmployeeValidators updatevalidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _addValidator = addValidator;
            _updatevalidator = updatevalidator;
        }

        public async Task<Response<string>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _addValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
           ", ",
           validationResult.Errors.Select(x => x.ErrorMessage)
       );

                return BadRequest<string>(errors);
            }
            var employeeMap = _mapper.Map<Employee>(request);
            await _unitOfWork.Employees.AddAsync(employeeMap);
            await _unitOfWork.SaveChangesAsync();
            return Created("Employee Created Successfully");
        }

        public async Task<Response<string>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
           
            var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return NotFound<string>("Employee Not Found");
            }
            await _unitOfWork.Employees.DeleteAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return Deleted<string>("Employee Deleted Successfully");
        }

        public async Task<Response<string>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
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
            var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return NotFound<string>("Employee Not Found");
            }
            //employee.Id = request.Id;
            //employee.Phone = request.Phone;
            //employee.Name = request.Name;
            //employee.Role = request.Role;
            //employee.ClinicId = request.ClinicId;
            _mapper.Map(request, employee);
            await _unitOfWork.Employees.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return Success("Employee UpDated Succefuly");
        }
    }
}
