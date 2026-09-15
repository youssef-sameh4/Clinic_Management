using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Patients.Queries.DTOS
{
    public  class GetPatientsByIdDTO
    {
        public GetPatientsByIdDTO(int id, string name, string phone, string gender, string address, string? email, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Gender = gender;
            Address = address;
            Email = email;
            DateOfBirth = dateOfBirth;
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
