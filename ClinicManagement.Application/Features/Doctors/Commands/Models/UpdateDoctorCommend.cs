using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Doctors.Commands.Models
{
    public class UpdateDoctorCommend:IRequest<Response<string>>
    {
        public UpdateDoctorCommend(string name, string phone, string specialization, decimal consultationFee, string description, int id)
        {
            Name = name;
            Phone = phone;
            Specialization = specialization;
            ConsultationFee = consultationFee;
            Description = description;
            Id = id;
        }
        public int Id { get; set; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Specialization { set; get; }
        public decimal ConsultationFee { set; get; }
        public string Description { set; get; }
    }
}
