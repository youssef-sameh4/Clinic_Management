using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Clinics.Commands.Models
{
    public class AddClinicCommand:IRequest<Response<string>>
    {
        public AddClinicCommand(string name, string address, int doctorId)
        {
            Name = name;
            Address = address;
            DoctorId = doctorId;
        }

        public string Name { set; get; }
        public string Address { set; get; }
        public int DoctorId { set; get; }
    }
}
