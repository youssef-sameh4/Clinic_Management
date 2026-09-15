using AutoMapper;
using ClinicManagement.Application.Bases;
using ClinicManagement.Application.Bases.ClinicManagement.Application.Bases;
using ClinicManagement.Application.Features.Schedules.Commands.Modles;
using ClinicManagement.Application.Features.Schedules.Commands.Validators;
using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Schedules.Commands.Handlers
{
    public class SchedulesHandlers : ResponseHandler, IRequestHandler<AddSchedulesCommand, Response<string>>,
        IRequestHandler<UpdateSchedulesCommand, Response<string>>,
        IRequestHandler<DeleteSchedulesCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AddSchedulesValidator _addSchedulesValidator;
        private readonly UpdateSchedulesValidator _updateSchedulesValidator;

        public SchedulesHandlers(IUnitOfWork unitOfWork, IMapper mapper, AddSchedulesValidator addSchedulesValidator, UpdateSchedulesValidator updateSchedulesValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _addSchedulesValidator = addSchedulesValidator;
            _updateSchedulesValidator = updateSchedulesValidator;
        }

        public async Task<Response<string>> Handle(AddSchedulesCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _addSchedulesValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
           ", ",
           validationResult.Errors.Select(x => x.ErrorMessage)
       );

                return BadRequest<string>(errors);
            }
            var schedulesMap = _mapper.Map<Schedule>(request);
            await _unitOfWork.Schedules.AddAsync(schedulesMap);
            await _unitOfWork.SaveChangesAsync();
            return Created("Schedule Add Successfully ");
        }

        public async Task<Response<string>> Handle(UpdateSchedulesCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _updateSchedulesValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(
           ", ",
           validationResult.Errors.Select(x => x.ErrorMessage)
       );

                return BadRequest<string>(errors);
            }
            var schedules = await _unitOfWork.Schedules.GetByIdAsync(request.Id);
            if (schedules == null)
            {
                return BadRequest<string>("schedules Not Found");
            }
            _mapper.Map(request, schedules);
            await _unitOfWork.Schedules.UpdateAsync(schedules);
            await _unitOfWork.Schedules.SaveChangesAsync();
            return Success("Schedule Updated Successfully");
        }

        public async  Task<Response<string>> Handle(DeleteSchedulesCommand request, CancellationToken cancellationToken)
        {
            var schedules = await _unitOfWork.Schedules.GetByIdAsync(request.Id);
            if (schedules == null)
            {
                return BadRequest<string>("schedules Not Found");
            }
            await _unitOfWork.Schedules.DeleteAsync(schedules);
            await _unitOfWork.SaveChangesAsync();
            return Deleted<string>("Schedule Deleted Successfully");
        }
    }
}
