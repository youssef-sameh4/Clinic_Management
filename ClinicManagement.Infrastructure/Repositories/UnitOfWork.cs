using ClinicManagement.Application.Interfaces;
using ClinicManagement.Domain.Entities;
using ClinicManagement.Infrastructure.Data;
using ClinicManagement.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            Doctors = new GenericRepositoryAsync<Doctor>(_dbContext);
            Patients = new GenericRepositoryAsync<Patient>(_dbContext);
            Clinics = new GenericRepositoryAsync<Clinic>(_dbContext);
            Appointments = new GenericRepositoryAsync<Appointment>(_dbContext);
            Payments = new GenericRepositoryAsync<Payment>(_dbContext);
            Prescriptions = new GenericRepositoryAsync<Prescription>(_dbContext);
            Schedules = new GenericRepositoryAsync<Schedule>(_dbContext);
            Employees = new GenericRepositoryAsync<Employee>(_dbContext);
        }
        public IGenericRepositoryAsync<Doctor> Doctors { get; }
        public IGenericRepositoryAsync<Patient> Patients { get; }
        public IGenericRepositoryAsync<Clinic> Clinics { get; }
        public IGenericRepositoryAsync<Appointment> Appointments { get; }
        public IGenericRepositoryAsync<Payment> Payments { get; }
        public IGenericRepositoryAsync<Prescription> Prescriptions { get; }
        public IGenericRepositoryAsync<Schedule> Schedules { get; }
        public IGenericRepositoryAsync<Employee> Employees { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task BeginTransactionAsync(IsolationLevel isolationLevel)
        {
            await _dbContext.Database.BeginTransactionAsync(isolationLevel);
        }

        public async Task CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
    }
}
