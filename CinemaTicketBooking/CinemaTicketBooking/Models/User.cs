namespace CinemaTicketBooking.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; } // For simplicity, we store the token directly
    }
}
