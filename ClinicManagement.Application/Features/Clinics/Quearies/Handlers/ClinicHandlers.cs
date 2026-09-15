using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Clinics.Quearies.DTOS;
using ClinicManagement.Application.Features.Clinics.Quearies.Models;
using ClinicManagement.Application.Features.Patients.Queries.DTOS;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Clinics.Quearies.Handlers
{
    public class ClinicHandlers : ResponseHandler, IRequestHandler<GetAllClinicQuery, Response<List<GetAllClinicDTO>>>,
        IRequestHandler<GetClinicByIdQuery, Response<GetClinicByIdDTO>>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClinicHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async  Task<Response<List<GetAllClinicDTO>>> Handle(GetAllClinicQuery request, CancellationToken cancellationToken)
        {
            var clinics =  _unitOfWork.Clinics.GetTableNoTracking();
            var clinicsMap = _mapper.Map<List<GetAllClinicDTO>>(clinics);
            return Success(clinicsMap);
        }

        public async Task<Response<GetClinicByIdDTO>> Handle(GetClinicByIdQuery request, CancellationToken cancellationToken)
        {
            var clinic = await _unitOfWork.Clinics.GetByIdAsync(request.Id);
          
                if (clinic == null)
                {
                    return NotFound<GetClinicByIdDTO>("clinic Not Found");
                }
            var clinMap = _mapper.Map<GetClinicByIdDTO>(clinic);
            return Success(clinMap);

            
        }
    }
}
