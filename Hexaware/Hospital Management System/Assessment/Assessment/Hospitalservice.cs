using System;
using System.Data.SqlClient;

public class HospitalService
{
    private readonly string connectionString = "Data Source=BUVAN\\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;";

    public Appointment GetAppointmentById(int id)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE AppointmentId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

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

                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("DB Error: " + ex.Message);
            return null;
        }
    }
}
