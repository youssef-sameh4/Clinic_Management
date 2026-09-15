using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Clinics.Mapping
{
    public partial class ClinicProfile:Profile
    {
        public ClinicProfile()
        {
            AddClinicMapping();
            UpdateClinicMapping();
            GetAllClinicsMapping();
            GetClinicByIdMapping();
        }
    }
}
