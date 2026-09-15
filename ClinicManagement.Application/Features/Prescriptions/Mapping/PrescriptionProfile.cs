using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Prescriptions.Mapping
{
    public partial class PrescriptionProfile:Profile
    {
        public PrescriptionProfile()
        {
            AddPrescriptionMapping();
        }
    }
}
