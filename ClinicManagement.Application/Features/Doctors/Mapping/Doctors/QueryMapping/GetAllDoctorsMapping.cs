using ClinicManagement.Application.Features.Doctors.Commands.Models;
using ClinicManagement.Application.Features.Doctors.Query.DTOS;
using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Mapping.Doctors
{
    public partial class DoctorProfiles
    {
        public void GetAllDoctosrMapping()
        {

            CreateMap<Doctor, GetAllDoctorDTO>();
        }
    }
}
