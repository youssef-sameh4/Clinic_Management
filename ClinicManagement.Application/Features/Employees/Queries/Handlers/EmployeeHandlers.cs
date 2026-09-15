using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Employees.Queries.DTOS;
using ClinicManagement.Application.Features.Employees.Queries.Modles;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Employees.Queries.Handlers
{
    public class EmployeeHandlers : ResponseHandler, IRequestHandler<GetAllEmployeeQuery, Response<List<GetAllEmployeesDTO>>>,
        IRequestHandler<GetEmployeeByIdQuery, Response<GetEmployeeByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<Response<GetEmployeeByIdDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return NotFound<GetEmployeeByIdDto>("Employee Not Found");
            }

            var result = _mapper.Map<GetEmployeeByIdDto>(employee);
            return Success(result);
        }
    

    public async Task<Response<List<GetAllEmployeesDTO>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = _unitOfWork.Employees.GetTableNoTracking();
            var employeesMap = _mapper.Map<List<GetAllEmployeesDTO>>(employees);
            return Success(employeesMap);
        }
    }
}
