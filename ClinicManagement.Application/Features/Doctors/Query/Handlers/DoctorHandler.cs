using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Doctors.Query.DTOS;
using ClinicManagement.Application.Features.Doctors.Query.Models;
using ClinicManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Query.Handlers
{
    public class DoctorHandler : ResponseHandler, IRequestHandler<GetAllDoctorQuery,Response<List<GetAllDoctorDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAllDoctorDTO>>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            var doctors = _unitOfWork.Doctors.GetTableNoTracking();
            var result = _mapper.Map<List<GetAllDoctorDTO>>(doctors);
            return Success(result);
        }
    }
}
