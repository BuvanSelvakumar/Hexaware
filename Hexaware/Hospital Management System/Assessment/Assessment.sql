CREATE DATABASE HospitalDB;
USE HospitalDB;

CREATE TABLE Patient (
    PatientId INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    ContactNumber VARCHAR(20),
    Address VARCHAR(100)
);

CREATE TABLE Doctor (
    DoctorId INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Specialization VARCHAR(50),
    ContactNumber VARCHAR(20)
);

CREATE TABLE Appointment (
    AppointmentId INT PRIMARY KEY,
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    DoctorId INT FOREIGN KEY REFERENCES Doctor(DoctorId),
    AppointmentDate DATE,
    Description VARCHAR(255)
);

INSERT INTO Patient VALUES
(1, 'Jack', 'Son', '09-04-2000', 'Male', '1234567890', 'Delhi'),
(2, 'John', 'Son', '10-04-2000', 'Female', '9876543210', 'Mumbai');

INSERT INTO Doctor VALUES
(1, 'Dr. Raj', 'Singh', 'Cardiology', '1112223333'),
(2, 'Dr. Pal', 'Raj', 'Dermatology', '4445556666');

INSERT INTO Appointment VALUES
(1001, 1, 1, '05-04-2025', 'Regular check-up'),
(1002, 2, 2, '10-04-2025', 'Skin consultation');






