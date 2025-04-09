using System;
using System.Collections.Generic;
using HospitalManagement.DAO;

class Program
{
    static void Main(string[] args)
    {
        HospitalServiceImpl service = new HospitalServiceImpl();

        while (true)
        {
            Console.WriteLine("\n--- Hospital Management System ---");
            Console.WriteLine("1. View Appointment by ID");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Appointment ID: ");
                        int id = int.Parse(Console.ReadLine());
                        var app = service.GetAppointmentById(id);

                        if (app != null)
                        {
                            Console.WriteLine("Appointment Found: " + app);
                        }
                        else
                        {
                            throw new PatientNumberNotFoundException($"No appointment found with ID {id}");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            catch (PatientNumberNotFoundException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
