using AutoMapper.Execution;
using ClinicManagement.Application.Features.Doctors.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.Domain.Entities;
namespace ClinicManagement.Application.Features.Doctors.Mapping.Doctors
{
    public partial class DoctorProfiles
    {
        public void AddDoctorMapping()
        {
            CreateMap<AddDoctorCommand, Doctor>();
        }
    }
}
