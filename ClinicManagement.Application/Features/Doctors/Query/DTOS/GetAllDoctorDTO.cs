using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Query.DTOS
{
    public class GetAllDoctorDTO
    {
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Specialization { set; get; }
        public decimal ConsultationFee { set; get; }
        public string Description { set; get; }
    }
}
