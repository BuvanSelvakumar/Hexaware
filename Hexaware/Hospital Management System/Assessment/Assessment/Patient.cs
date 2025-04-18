﻿public class Patient
{
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }

    // Default constructor
    public Patient() { }

    // Parameterized constructor
    public Patient(int patientId, string firstName, string lastName, string dateOfBirth, string gender, string contactNumber, string address)
    {
        PatientId = patientId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        ContactNumber = contactNumber;
        Address = address;
    }

    public override string ToString()
    {
        return $"PatientId: {PatientId}, Name: {FirstName} {LastName}, DOB: {DateOfBirth}, Gender: {Gender}, Contact: {ContactNumber}, Address: {Address}";
    }
}
