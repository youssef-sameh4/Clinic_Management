using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Appointments.Query.DTOS;
using ClinicManagement.Application.Features.Appointments.Query.Models;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Appointments.Query.Handlers
{
    public class AppointmentHandlers : ResponseHandler, IRequestHandler<GetAllAppointmentsQuery, Response<List<GetAllAppointmentsDTO>>>
    {
        private readonly IUnitOfWork _uniteofwork;
        private readonly IMapper _mapper;

        public AppointmentHandlers(IUnitOfWork uniteofwork, IMapper mapper)
        {
            _uniteofwork = uniteofwork;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAllAppointmentsDTO>>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = _uniteofwork.Appointments.GetTableNoTracking();
            var result = _mapper.Map<List<GetAllAppointmentsDTO>>(appointments);
            return Success(result);
        }

    }
}
