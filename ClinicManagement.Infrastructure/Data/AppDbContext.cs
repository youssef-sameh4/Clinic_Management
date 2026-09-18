using ClinicManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Doctor> Doctors { set; get; }
        public DbSet<Appointment> Appointments { set; get; }
        public DbSet<Clinic> Clinics { set; get; }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<Payment> Payments { set; get; }
        public DbSet<Prescription> Prescriptions { set; get; }
        public DbSet<Schedule> Schedules { set; get; }
        public DbSet<Employee> Employees { set; get; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>().Property(x => x.ConsultationFee).HasPrecision(18, 2);
            modelBuilder.Entity<Appointment>().Property(x => x.ConsultationFee).HasPrecision(18, 2);
            modelBuilder.Entity<Payment>().Property(x => x.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Clinic>()
        .HasOne(c => c.Doctor)
        .WithMany(d => d.Clinics)
        .HasForeignKey(c => c.DoctorId)
        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
