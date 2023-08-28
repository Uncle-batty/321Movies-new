using Microsoft.AspNetCore.Mvc;
using _321MoviesAPI.Data;
 // Correct the namespace based on your actual model namespace
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using _321MoviesAPI.Modle;

namespace _321MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MyDataContext _db;

        public MoviesController(MyDataContext db)
        {
            _db = db;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movies = await _db.moviess.ToListAsync();
            return Ok(movies);
        }

        // GET api/Movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _db.moviess.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST api/Movies
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Movies movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }

            _db.moviess.Add(movie);
            await _db.SaveChangesAsync();

            return Created($"/api/Movies/{movie.Id}", movie);
        }

        // PUT api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Movies movie)
        {
            if (movie == null || movie.Id != id)
            {
                return BadRequest();
            }

            _db.Entry(movie).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _db.moviess.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _db.moviess.Remove(movie);
            await _db.SaveChangesAsync();

            return Ok(movie);
        }
    }
}
