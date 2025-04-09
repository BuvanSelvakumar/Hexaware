using System;

public class PatientNumberNotFoundException : Exception
{
    public PatientNumberNotFoundException() : base("Patient number not found.") { }

    public PatientNumberNotFoundException(string message) : base(message) { }
}
