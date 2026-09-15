using ClinicManagement.Application.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Commands.Models
{
    public class UpdatePatientCommand:IRequest<Response<string>>
    {
        public UpdatePatientCommand(string name, string phone, string gender, string address, string? email, DateTime dateOfBirth, int id)
        {
            Name = name;
            Phone = phone;
            Gender = gender;
            Address = address;
            Email = email;
            DateOfBirth = dateOfBirth;
            Id = id;
        }

        public int Id { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Gender { set; get; }
        public string Address { set; get; }
        public string? Email { set; get; }
        public DateTime DateOfBirth { get; set; }
    }
}
