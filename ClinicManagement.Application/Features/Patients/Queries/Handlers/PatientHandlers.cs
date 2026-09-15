using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Patients.Queries.DTOS;
using ClinicManagement.Application.Features.Patients.Queries.Models;
using ClinicManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Queries.Handlers
{
    public class PatientHandlers : ResponseHandler, IRequestHandler<GetAllPatientsQuery, Response<List<GetAllPatientsDTO>>>,
        IRequestHandler<GetPatientByIdQuery, Response<GetPatientsByIdDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAllPatientsDTO>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = _unitOfWork.Patients.GetTableNoTracking().ToList();
            var patientsMap = _mapper.Map<List<GetAllPatientsDTO>>(patients);
            return Success(patientsMap);
        }

        public async Task<Response<GetPatientsByIdDTO>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.Id);
            if (patient == null)
            {
                return NotFound<GetPatientsByIdDTO>("Patient Not Found");
            }
            var patientMap = _mapper.Map<GetPatientsByIdDTO>(patient);
            return Success(patientMap);
        }
    }
}
