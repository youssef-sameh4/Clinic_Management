using ClinicManagement.Application.Features.Clinics.Quearies.DTOS;
using ClinicManagement.Application.Features.Clinics.Quearies.Models;
using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Clinics.Mapping
{
    public partial class ClinicProfile
    {
        public void GetAllClinicsMapping()
        {
            CreateMap<Clinic, GetAllClinicDTO>();
        }
    }
}
