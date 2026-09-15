using ClinicManagement.Application.Features.Patients.Commands.Models;
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
        public void AddPatientMapping()
        {
            CreateMap<AddPatientCommand, Patient>();
        }
    }
}
