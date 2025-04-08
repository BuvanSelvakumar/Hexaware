using System;
using System.Collections.Generic;

namespace TicketBookingSystem
{
    // Task 4 - Classes

    // Task 6 - Abstraction



    public abstract class AbstractEvent
    {
        public string EventName { get; set; }
        public int AvailableSeats { get; set; }

        public AbstractEvent(string eventName, int availableSeats)
        {
            EventName = eventName;
            AvailableSeats = availableSeats;
        }

        public abstract void DisplayDetails();
        public abstract void BookTickets(int num);
        public abstract void CancelTickets(int num);
    }

    public class AbstractMovie : AbstractEvent
    {
        public string Genre { get; set; }

        public AbstractMovie(string name, int seats, string genre)
            : base(name, seats)
        {
            Genre = genre;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Movie: {EventName}, Genre: {Genre}, Seats: {AvailableSeats}");
        }

        public override void BookTickets(int num)
        {
            if (AvailableSeats >= num)
            {
                AvailableSeats -= num;
                Console.WriteLine($"{num} movie tickets booked.");
            }
            else
            {
                Console.WriteLine("Not enough seats available.");
            }
        }

        public override void CancelTickets(int num)
        {
            AvailableSeats += num;
            Console.WriteLine($"{num} movie tickets cancelled.");
        }
    }

    public class AbstractConcert : AbstractEvent
    {
        public string Artist { get; set; }

        public AbstractConcert(string name, int seats, string artist)
            : base(name, seats)
        {
            Artist = artist;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Concert: {EventName}, Artist: {Artist}, Seats: {AvailableSeats}");
        }

        public override void BookTickets(int num)
        {
            if (AvailableSeats >= num)
            {
                AvailableSeats -= num;
                Console.WriteLine($"{num} concert tickets booked.");
            }
            else
            {
                Console.WriteLine("Not enough seats available.");
            }
        }

        public override void CancelTickets(int num)
        {
            AvailableSeats += num;
            Console.WriteLine($"{num} concert tickets cancelled.");
        }
    }

    public class AbstractSport : AbstractEvent
    {
        public string Teams { get; set; }

        public AbstractSport(string name, int seats, string teams)
            : base(name, seats)
        {
            Teams = teams;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Sports: {EventName}, Teams: {Teams}, Seats: {AvailableSeats}");
        }

        public override void BookTickets(int num)
        {
            if (AvailableSeats >= num)
            {
                AvailableSeats -= num;
                Console.WriteLine($"{num} sports tickets booked.");
            }
            else
            {
                Console.WriteLine("Not enough seats available.");
            }
        }

        public override void CancelTickets(int num)
        {
            AvailableSeats += num;
            Console.WriteLine($"{num} sports tickets cancelled.");
        }
    }

    public abstract class BookingSystem
    {
        public abstract void CreateEvent(string type, string name, int seats, string extra);
        public abstract void BookTickets(string name, int num);
        public abstract void CancelTickets(string name, int num);
        public abstract void GetAvailableSeats(string name);
    }

    public class TicketBookingSystem6 : BookingSystem
    {
        private List<AbstractEvent> events = new List<AbstractEvent>();

        public override void CreateEvent(string type, string name, int seats, string extra)
        {
            AbstractEvent e = null;
            switch (type.ToLower())
            {
                case "movie":
                    e = new AbstractMovie(name, seats, extra);
                    break;
                case "concert":
                    e = new AbstractConcert(name, seats, extra);
                    break;
                case "sport":
                    e = new AbstractSport(name, seats, extra);
                    break;
            }

            if (e != null)
            {
                events.Add(e);
                Console.WriteLine($"{type} event '{name}' created.");
            }
            else
            {
                Console.WriteLine("Invalid event type.");
            }
        }

        public override void BookTickets(string name, int num)
        {
            AbstractEvent e = events.Find(ev => ev.EventName == name);
            if (e != null)
                e.BookTickets(num);
            else
                Console.WriteLine("Event not found.");
        }

        public override void CancelTickets(string name, int num)
        {
            AbstractEvent e = events.Find(ev => ev.EventName == name);
            if (e != null)
                e.CancelTickets(num);
            else
                Console.WriteLine("Event not found.");
        }

        public override void GetAvailableSeats(string name)
        {
            AbstractEvent e = events.Find(ev => ev.EventName == name);
            if (e != null)
                Console.WriteLine($"Available Seats for {name}: {e.AvailableSeats}");
            else
                Console.WriteLine("Event not found.");
        }

        public void DisplayAllEvents()
        {
            foreach (var e in events)
                e.DisplayDetails();
        }
    }

    public class Venue
    {
        public string VenueName { get; set; }
        public string Address { get; set; }

        public Venue() { }

        public Venue(string venueName, string address)
        {
            VenueName = venueName;
            Address = address;
        }

        public void DisplayVenueDetails()
        {
            Console.WriteLine($"Venue: {VenueName}, Address: {Address}");
        }
    }

    public class Customer
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer() { }

        public Customer(string name, string email, string phone)
        {
            CustomerName = name;
            Email = email;
            PhoneNumber = phone;
        }

        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"Customer: {CustomerName}, Email: {Email}, Phone: {PhoneNumber}");
        }
    }

    public class Event
    {
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        public Event() { }

        public Event(string name, string date, string time, string venue, int seats, decimal price, string type)
        {
            EventName = name;
            EventDate = date;
            EventTime = time;
            VenueName = venue;
            TotalSeats = seats;
            AvailableSeats = seats;
            TicketPrice = price;
            EventType = type;
        }

        public virtual void DisplayEventDetails()
        {
            Console.WriteLine($"{EventType} Event: {EventName} on {EventDate} at {EventTime}");
            Console.WriteLine($"Venue: {VenueName}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice}");
        }

        public int GetBookedNoOfTickets()
        {
            return TotalSeats - AvailableSeats;
        }

        public void BookTickets(int num)
        {
            if (num <= AvailableSeats)
            {
                AvailableSeats -= num;
                Console.WriteLine($"{num} tickets booked.");
            }
            else
            {
                Console.WriteLine("Not enough seats available.");
            }
        }

        public void CancelBooking(int num)
        {
            AvailableSeats += num;
            Console.WriteLine($"{num} tickets cancelled.");
        }

        public decimal CalculateTotalRevenue()
        {
            return GetBookedNoOfTickets() * TicketPrice;
        }
    }

    // Task 5 - Inheritance & Polymorphism
    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie() { }

        public Movie(string name, string date, string time, Venue venue, int seats, decimal price, string genre, string actor, string actress)
      : base(name, date, time, venue.VenueName, seats, price, "Movie")
        {
            Genre = genre;
            ActorName = actor;
            ActressName = actress;
        }


        public override void DisplayEventDetails()
        {
            base.DisplayEventDetails();
            Console.WriteLine($"Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}");
        }
    }

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        public Concert() { }

        public Concert(string name, string date, string time, string venue, int seats, decimal price, string artist, string type)
            : base(name, date, time, venue, seats, price, "Concert")
        {
            Artist = artist;
            Type = type;
        }

        public void DisplayConcertDetails()
        {
            base.DisplayEventDetails();
            Console.WriteLine($"Artist: {Artist}, Type: {Type}");
        }
    }

    public class Sports : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sports() { }

        public Sports(string name, string date, string time, string venue, int seats, decimal price, string sport, string teams)
            : base(name, date, time, venue, seats, price, "Sports")
        {
            SportName = sport;
            TeamsName = teams;
        }

        public void DisplaySportDetails()
        {
            base.DisplayEventDetails();
            Console.WriteLine($"Sport: {SportName}, Teams: {TeamsName}");
        }
    }

    class Program
    {
        // Task 1
        public static void task_1()
        {
            Console.Write("Enter available tickets: ");
            int available = int.Parse(Console.ReadLine());

            Console.Write("Enter tickets to book: ");
            int toBook = int.Parse(Console.ReadLine());

            if (available >= toBook)
            {
                Console.WriteLine($"Booking successful. Remaining tickets: {available - toBook}");
            }
            else
            {
                Console.WriteLine("Tickets unavailable.");
            }
        }

        // Task 2
        // Task 2 - C# 7.3 compatible version
        public static void task_2()
        {
            Console.WriteLine("Ticket Categories: Silver, Gold, Diamond");
            Console.Write("Enter ticket type: ");
            string type = Console.ReadLine().ToLower();

            decimal price = 0;

            if (type == "silver")
                price = 100;
            else if (type == "gold")
                price = 200;
            else if (type == "diamond")
                price = 300;
            else
            {
                Console.WriteLine("Invalid ticket type.");
                return;
            }

            Console.Write("Enter number of tickets: ");
            int qty = int.Parse(Console.ReadLine());

            Console.WriteLine($"Total cost: {qty * price}");
        }


        // Task 3
        public static void task_3()
        {
            while (true)
            {
                Console.Write("Type 'Exit' to stop or press Enter to continue: ");
                if (Console.ReadLine().ToLower() == "exit") break;
                task_2();
            }
        }

        // Task 4 & 5 continue as implemented above...

        static void Main(string[] args)
        {
            // You can uncomment the function below to test each task individually
            //task_1();
            //task_2();
            //task_3();

            // You can continue testing the rest (task 4, 5) by creating objects here

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n====== Ticket Booking System Menu ======");
                Console.WriteLine("1. Task 1 - Basic Ticket Booking Check");
                Console.WriteLine("2. Task 2 - Ticket Category & Price Calculation");
                Console.WriteLine("3. Task 3 - Loop Ticket Booking Until Exit");
                Console.WriteLine("4. Task 4 - Event, Venue, Customer, Booking Classes");
                Console.WriteLine("5. Task 5 - Inheritance & Polymorphism (Movie, Sports, Concert)");
                Console.WriteLine("6. Task 6 - Abstraction (Booking System Interface)");
                Console.WriteLine("7. Task 7 - Has-A Relationship / Association");


                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice (1-8): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        task_1();
                        break;
                    case "2":
                        task_2();
                        break;
                    case "3":
                        task_3();
                        break;
                    case "4":
                        Console.WriteLine("\n--- Task 4 Demonstration ---");
                        Event ev = new Event("Rock Show", "2025-05-01", "7:00 PM", "Grand Arena", 100, 250.0m, "Concert");
                        ev.DisplayEventDetails();
                        ev.BookTickets(5);
                        Console.WriteLine($"Total Revenue: {ev.CalculateTotalRevenue()}");
                        break;
                    case "5":
                        Console.WriteLine("\n--- Task 5 Demonstration ---");
                        Venue imaxVenue = new Venue("IMAX", "123 Theater Street");
                        Movie m = new Movie("Inception", "2025-05-10", "6:30 PM", imaxVenue, 80, 300.0m, "Sci-Fi", "Leonardo DiCaprio", "Elliot Page");
                        m.DisplayEventDetails();

                        Concert c = new Concert("Classical Night", "2025-06-01", "8:00 PM", "Opera Hall", 60, 200.0m, "Mozart Band", "Classical");
                        c.DisplayConcertDetails();
                        Sports s = new Sports("Cricket World Cup", "2025-07-15", "4:00 PM", "National Stadium", 500, 500.0m, "Cricket", "India vs Pakistan");
                        s.DisplaySportDetails();
                        break;

                    case "6":
                        Console.WriteLine("\n--- Task 6 Demonstration ---");
                        TicketBookingSystem6 bookingSystem = new TicketBookingSystem6();
                        bool task6Running = true;

                        while (task6Running)
                        {
                            Console.Write("\nCommand (create_event, book_tickets, cancel_tickets, get_available_seats, show_events, exit): ");
                            string command = Console.ReadLine().ToLower();

                            switch (command)
                            {
                                case "create_event":
                                    Console.Write("Type (movie/concert/sport): ");
                                    string type = Console.ReadLine();
                                    Console.Write("Event name: ");
                                    string name = Console.ReadLine();
                                    Console.Write("Seats: ");
                                    int seats = int.Parse(Console.ReadLine());
                                    Console.Write("Extra (genre/artist/teams): ");
                                    string extra = Console.ReadLine();
                                    bookingSystem.CreateEvent(type, name, seats, extra);
                                    break;
                                case "book_tickets":
                                    Console.Write("Event name: ");
                                    name = Console.ReadLine();
                                    Console.Write("No. of tickets: ");
                                    int bookCount = int.Parse(Console.ReadLine());
                                    bookingSystem.BookTickets(name, bookCount);
                                    break;
                                case "cancel_tickets":
                                    Console.Write("Event name: ");
                                    name = Console.ReadLine();
                                    Console.Write("No. of tickets to cancel: ");
                                    int cancelCount = int.Parse(Console.ReadLine());
                                    bookingSystem.CancelTickets(name, cancelCount);
                                    break;
                                case "get_available_seats":
                                    Console.Write("Event name: ");
                                    name = Console.ReadLine();
                                    bookingSystem.GetAvailableSeats(name);
                                    break;
                                case "show_events":
                                    bookingSystem.DisplayAllEvents();
                                    break;
                                case "exit":
                                    task6Running = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid command.");
                                    break;
                            }
                        }
                        break;

                    case "7":
                        Console.WriteLine("\n--- Task 7 Demonstration ---");

                        // Venue object
                        Venue venue = new Venue("City Hall", "123 Main Street");

                        // Event object (Movie)
                        Movie movie = new Movie(
                            "Interstellar", "2025-08-01", "6:00 PM", venue, 100, 250.0m, "Sci-Fi", "Matthew McConaughey", "Anne Hathaway"
                        );

                        // Display event details (has-a Venue)
                        movie.DisplayEventDetails();

                        // Create customer array
                        Customer[] customers = new Customer[]
                        {
        new Customer("John Doe", "john@example.com", "9876543210"),
        new Customer("Jane Smith", "jane@example.com", "9123456789")
                        };

                        // Book 2 tickets
                        movie.BookTickets(customers.Length);

                        // Display revenue
                        Console.WriteLine($"Total Revenue: ₹{movie.CalculateTotalRevenue()}");

                        // Display each customer info
                        foreach (var cust in customers)
                        {
                            cust.DisplayCustomerDetails();
                        }

                        break;


                    case "8":
                        running = false;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
