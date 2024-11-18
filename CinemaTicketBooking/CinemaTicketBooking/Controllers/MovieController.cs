using Microsoft.AspNetCore.Mvc;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.DataHelper;

namespace CinemaTicketBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(InMemoryStorage.Movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = InMemoryStorage.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound(new { message = "Movie not found." });

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie newMovie)
        {
            newMovie.MovieId = InMemoryStorage.Movies.Max(m => m.MovieId) + 1;
            InMemoryStorage.Movies.Add(newMovie);
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.MovieId }, newMovie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var movie = InMemoryStorage.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound(new { message = "Movie not found." });

            movie.Title = updatedMovie.Title;
            movie.Description = updatedMovie.Description;
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = InMemoryStorage.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound(new { message = "Movie not found." });

            InMemoryStorage.Movies.Remove(movie);
            return Ok(new { message = "Movie deleted successfully." });
        }
    }
}
