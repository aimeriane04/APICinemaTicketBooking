namespace CinemaTicketBooking.Models
{
    public class Showtime
    {
        public int ShowtimeId { get; set; }
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Auditorium { get; set; }
    }
}
