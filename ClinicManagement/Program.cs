using ClinicManagement.Application;
using ClinicManagement.Application.Features.Appointments.Command.Payments;
using ClinicManagement.Application.Features.Appointments.Validators;
using ClinicManagement.Application.Features.Clinics.Validator;
using ClinicManagement.Application.Features.Doctors.Commands.NewFolder;
using ClinicManagement.Application.Features.Doctors.Commands.Validators;
using ClinicManagement.Application.Features.Employees.Commands.Validators;
using ClinicManagement.Application.Features.Patients.Commands.Validators;
using ClinicManagement.Application.Features.Prescriptions.Commands.Validators;
using ClinicManagement.Application.Features.Schedules.Commands.Validators;
using ClinicManagement.Infrastructure;
using ClinicManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAppDependance();
builder.Services.AddInfrustrctureDependance();
builder.Services.AddScoped<AddDoctorValidator>();
builder.Services.AddScoped<UpdateDoctorValidator>();
builder.Services.AddScoped<AddPatientValidator>();
builder.Services.AddScoped<UpdatePatientValidator>();
builder.Services.AddScoped<AddClinicValidator>();
builder.Services.AddScoped<UpdateClinicValidator>();
builder.Services.AddScoped<AddEmployeeValidators>();
builder.Services.AddScoped<UpdateEmployeeValidators>();
builder.Services.AddScoped<AddSchedulesValidator>();
builder.Services.AddScoped<UpdateSchedulesValidator>();
builder.Services.AddScoped<AddPrescriptionValidator>();
builder.Services.AddScoped<PaymentValidator>();
builder.Services.AddScoped<BookAppointmentValidator>();
builder.Services.AddScoped<UpdateAppointmentValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
