using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Clinics.Quearies.DTOS
{
    public class GetAllClinicDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public int DoctorId { set; get; }
    }
}
