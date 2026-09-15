using ClinicManagement.Application.Features.Patients.Queries.DTOS;
using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Mapping
{
    public partial class PatientProfile 
    {
        public void GetAllPatientsMapping()
        {
            CreateMap<Patient, GetAllPatientsDTO>();
        }
    }
}
