using Microsoft.AspNetCore.Mvc;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.DataHelper;

namespace CinemaTicketBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowtimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllShowtimes()
        {
            return Ok(InMemoryStorage.Showtimes);
        }

        [HttpGet("{id}")]
        public IActionResult GetShowtimeById(int id)
        {
            var showtime = InMemoryStorage.Showtimes.FirstOrDefault(s => s.ShowtimeId == id);
            if (showtime == null)
                return NotFound(new { message = "Showtime not found." });

            return Ok(showtime);
        }

        [HttpPost]
        public IActionResult CreateShowtime([FromBody] Showtime showtime)
        {
            if (InMemoryStorage.Movies.All(m => m.MovieId != showtime.MovieId))
                return BadRequest(new { message = "Invalid MovieId. Movie does not exist." });

            showtime.ShowtimeId = InMemoryStorage.Showtimes.Max(s => s.ShowtimeId) + 1;
            InMemoryStorage.Showtimes.Add(showtime);
            return CreatedAtAction(nameof(GetShowtimeById), new { id = showtime.ShowtimeId }, showtime);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShowtime(int id, [FromBody] Showtime updatedShowtime)
        {
            var existingShowtime = InMemoryStorage.Showtimes.FirstOrDefault(s => s.ShowtimeId == id);
            if (existingShowtime == null)
                return NotFound(new { message = "Showtime not found." });

            if (InMemoryStorage.Movies.All(m => m.MovieId != updatedShowtime.MovieId))
                return BadRequest(new { message = "Invalid MovieId. Movie does not exist." });

            existingShowtime.MovieId = updatedShowtime.MovieId;
            existingShowtime.StartTime = updatedShowtime.StartTime;
            existingShowtime.EndTime = updatedShowtime.EndTime;
            existingShowtime.Auditorium = updatedShowtime.Auditorium;

            return Ok(existingShowtime);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShowtime(int id)
        {
            var showtime = InMemoryStorage.Showtimes.FirstOrDefault(s => s.ShowtimeId == id);
            if (showtime == null)
                return NotFound(new { message = "Showtime not found." });

            InMemoryStorage.Showtimes.Remove(showtime);
            return NoContent();
        }
    }
}
