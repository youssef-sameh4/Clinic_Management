using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        IGenericRepositoryAsync<Doctor> Doctors { get; }
        IGenericRepositoryAsync<Patient> Patients { get; }
        IGenericRepositoryAsync<Clinic> Clinics { get; }
        IGenericRepositoryAsync<Appointment> Appointments { get; }
        public IGenericRepositoryAsync<Payment> Payments { get; }
        public IGenericRepositoryAsync<Prescription> Prescriptions { get; }
        public IGenericRepositoryAsync<Schedule> Schedules { get; }
        public IGenericRepositoryAsync<Employee> Employees { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync(IsolationLevel isolationLevel);
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
