using ClinicManagement.Application.Bases;
using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicManagement.Application.Features.Clinics.Commands.Models
{
    public class UpdateClinicCommand:IRequest<Response<string>>
    {
        public UpdateClinicCommand(string name, string address, int doctorId, int id)
        {
            Name = name;
            Address = address;
            DoctorId = doctorId;
            Id = id;
        }

        public int Id { set; get; }
    public string Name { set; get; }
    public string Address { set; get; }
    public int DoctorId { set; get; }
}
}
