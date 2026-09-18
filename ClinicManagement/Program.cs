using ClinicManagement.Application;
using ClinicManagement.Application.BackgroundJobs;
using ClinicManagement.Application.Features.Appointments.Command.Payments;
using ClinicManagement.Application.Features.Appointments.Validators;
using ClinicManagement.Application.Features.Clinics.Validator;
using ClinicManagement.Application.Features.Doctors.Commands.NewFolder;
using ClinicManagement.Application.Features.Doctors.Commands.Validators;
using ClinicManagement.Application.Features.Employees.Commands.Validators;
using ClinicManagement.Application.Features.Patients.Commands.Validators;
using ClinicManagement.Application.Features.Prescriptions.Commands.Validators;
using ClinicManagement.Application.Features.Schedules.Commands.Validators;
using ClinicManagement.Domain.Entities;
using ClinicManagement.Infrastructure;
using ClinicManagement.Infrastructure.Auth;
using ClinicManagement.Infrastructure.Data;
using ClinicManagement.Infrastructure.Email;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

// =====================================================
// Database
// =====================================================

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// =====================================================
// Identity
// =====================================================

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// =====================================================
// JWT Authentication
// =====================================================

var jwtSettings = builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>();

if (jwtSettings == null)
{
    throw new Exception(
        $"JwtSettings section exists: {builder.Configuration.GetSection("JwtSettings").Exists()}"
    );
}

var key = Encoding.UTF8.GetBytes(jwtSettings.Key);
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultChallengeScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultScheme =
            JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,

            IssuerSigningKey =
                new SymmetricSecurityKey(key),

            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,

            NameClaimType = ClaimTypes.NameIdentifier,
            RoleClaimType = ClaimTypes.Role
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// =====================================================
// Hangfire
// =====================================================

builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connectionString);
});

builder.Services.AddHangfireServer();

builder.Services.AddScoped<AppointmentEmailJob>();

// =====================================================
// Settings
// =====================================================

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

// =====================================================
// Controllers
// =====================================================

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// =====================================================
// Swagger + JWT
// =====================================================

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// =====================================================
// Application + Infrastructure Dependencies
// =====================================================

builder.Services.AddAppDependance();

builder.Services.AddInfrustrctureDependance();

// =====================================================
// Validators
// =====================================================

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

// =====================================================
// Build
// =====================================================

var app = builder.Build();

// =====================================================
// HTTP Request Pipeline
// =====================================================

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();