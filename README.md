# 🏥 Clinic Management System

> A backend system for managing clinic operations, appointments, schedules, payments, prescriptions, and user access using ASP.NET Core Web API and Clean Architecture.

---

## 📌 Overview

**Clinic Management System** is a backend-focused application designed to manage the main workflow of a clinic, starting from user authentication and doctor/clinic management to appointment booking, payment tracking, prescription management, and automated appointment confirmation emails.

The main goal of the project was not just to build a collection of CRUD APIs, but to implement a backend system that handles **real-world business rules**, validates operations before modifying the database, and keeps responsibilities separated through **Clean Architecture**.

---

## 💡 The Problem

Managing a clinic involves more than storing doctors and patients in a database.

A real clinic needs to handle:

- Doctors and their working schedules
- Patients and staff
- Clinics and doctor assignments
- Appointment booking
- Schedule validation
- Appointment conflicts
- Queue numbers
- Consultation fees
- Payment tracking
- Prescriptions
- Appointment confirmation
- Different user roles and permissions

For example, when a patient books an appointment, the system should not simply create a new database record.

It needs to verify that:

1. The doctor exists.
2. The patient exists.
3. The clinic exists.
4. The doctor is associated with the selected clinic.
5. The requested time is within the doctor's schedule.
6. There is no conflicting appointment.
7. The appointment data is valid.

Only after these rules are satisfied should the appointment be created.

---

## 🎯 Project Goals

- Apply **Clean Architecture** in a real-world backend project.
- Implement authentication and authorization.
- Separate business logic from controllers and infrastructure.
- Handle appointment and scheduling business rules.
- Prevent conflicting appointments.
- Validate incoming requests.
- Implement background processing.
- Send automated appointment confirmation emails.
- Build a backend that can be consumed by a separate frontend application.

---

# ✨ Main Features

### 🔐 Authentication & Authorization

- User registration and login
- ASP.NET Core Identity
- Role-based authorization
- JWT authentication
- Protected API endpoints
- User roles and permissions

### 👨‍⚕️ Doctor Management

- Create doctors
- Update doctors
- Delete doctors
- Manage doctor information
- Configure consultation fees
- Associate doctors with clinics
- Manage doctor schedules

### 🏥 Clinic Management

- Create clinics
- Update clinics
- Delete clinics
- Retrieve clinic information
- Associate clinics with doctors

### 👤 Patient Management

- Patient registration and authentication
- Patient information management
- Appointment association
- Prescription association

### 👨‍💼 Employee Management

The system supports clinic employees/staff with dedicated APIs and validation.

### 🕐 Doctor Scheduling

Doctors can have defined working schedules based on:

- Day
- Start Time
- End Time

The appointment booking process validates that the requested appointment time falls within the doctor's working schedule.

### 📅 Appointment Management

Appointment booking is one of the main business workflows in the system.

The booking process performs several validations before creating an appointment:

```text
Patient
   ↓
Select Doctor
   ↓
Select Clinic
   ↓
Select Appointment Time
   ↓
Validate Doctor
   ↓
Validate Patient
   ↓
Validate Clinic
   ↓
Validate Doctor / Clinic Relationship
   ↓
Validate Doctor Schedule
   ↓
Check Appointment Conflict
   ↓
Create Appointment
   ↓
Assign Queue Number
   ↓
Handle Payment Information
   ↓
Send Confirmation Email
