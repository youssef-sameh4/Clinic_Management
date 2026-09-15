using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Mapping.Doctors
{
    public partial class DoctorProfiles:Profile
    {
        public DoctorProfiles()
        {
            AddDoctorMapping();
            GetAllDoctosrMapping();
        }
    }
}
