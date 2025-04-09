public class Doctor
{
    public int DoctorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public string ContactNumber { get; set; }

    // Default constructor
    public Doctor() { }

    // Parameterized constructor
    public Doctor(int doctorId, string firstName, string lastName, string specialization, string contactNumber)
    {
        DoctorId = doctorId;
        FirstName = firstName;
        LastName = lastName;
        Specialization = specialization;
        ContactNumber = contactNumber;
    }

    public override string ToString()
    {
        return $"DoctorId: {DoctorId}, Name: {FirstName} {LastName}, Specialization: {Specialization}, Contact: {ContactNumber}";
    }
}
