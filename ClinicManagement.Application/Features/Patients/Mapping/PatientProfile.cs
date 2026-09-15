using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Mapping
{
    public partial class PatientProfile:Profile
    {
        public PatientProfile()
        {
            GatPatientByIdMapping();
            GetAllPatientsMapping();
            UpdatePatientMapping();
            AddPatientMapping();
        }
    }
}
