using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HospitalManagement;

namespace HospitalManagement.DAO
{
    public class HospitalServiceImpl : IHospitalService
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=HospitalDB;Integrated Security=True;";

        public Appointment GetAppointmentById(int appointmentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Appointment WHERE AppointmentId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", appointmentId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Appointment
                        {
                            AppointmentId = (int)reader["AppointmentId"],
                            PatientId = (int)reader["PatientId"],
                            DoctorId = (int)reader["DoctorId"],
                            AppointmentDate = reader["AppointmentDate"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Error: " + ex.Message);
            }

            return null;
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId) => throw new NotImplementedException();
        public List<Appointment> GetAppointmentsForDoctor(int doctorId) => throw new NotImplementedException();
        public bool ScheduleAppointment(Appointment appointment) => throw new NotImplementedException();
        public bool UpdateAppointment(Appointment appointment) => throw new NotImplementedException();
        public bool CancelAppointment(int appointmentId) => throw new NotImplementedException();
    }
}
