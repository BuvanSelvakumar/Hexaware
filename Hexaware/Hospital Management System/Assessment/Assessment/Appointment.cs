public class Appointment
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public string AppointmentDate { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"ID: {AppointmentId}, Patient: {PatientId}, Doctor: {DoctorId}, Date: {AppointmentDate}, Desc: {Description}";
    }
}
