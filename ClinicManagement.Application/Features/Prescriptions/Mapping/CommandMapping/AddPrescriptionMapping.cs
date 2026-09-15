using ClinicManagement.Application.Features.Prescriptions.Commands.Models;
using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Prescriptions.Mapping
{
    public partial class PrescriptionProfile
    {
        public void AddPrescriptionMapping()
        {
            CreateMap<AddPrescriptionCommand, Prescription>();
        }
    }
}
