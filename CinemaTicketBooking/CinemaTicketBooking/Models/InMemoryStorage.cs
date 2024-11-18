using System.Collections.Generic;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models;

namespace CinemaTicketBooking.DataHelper
{
    public static class InMemoryStorage
    {
        public static List<User> Users = new()
        {
            new User { UserId = 1, Username = "john_doe", Password = "password123" },
            new User { UserId = 2, Username = "jane_smith", Password = "securepass" }
        };

        public static List<Movie> Movies = new()
        {
            new Movie { MovieId = 1, Title = "Inception", Description = "A mind-bending thriller by Christopher Nolan." },
            new Movie { MovieId = 2, Title = "Titanic", Description = "A romantic drama by James Cameron." }
        };

        public static List<Showtime> Showtimes = new()
        {
            new Showtime { ShowtimeId = 1, MovieId = 1, StartTime = DateTime.Now.AddHours(1), EndTime = DateTime.Now.AddHours(3), Auditorium = "Auditorium 1" },
            new Showtime { ShowtimeId = 2, MovieId = 2, StartTime = DateTime.Now.AddHours(2), EndTime = DateTime.Now.AddHours(4), Auditorium = "Auditorium 2" }
        };
    }
}