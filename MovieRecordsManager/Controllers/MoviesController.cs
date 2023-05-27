using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRecordsManager.Models;

namespace MovieRecordsManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly MovieContext _dbContext;

		public MoviesController(MovieContext dbContext)
		{
			_dbContext = dbContext;
		}

		// GET: api/Movies
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
		{
			if (_dbContext.Movies == null)
			{
				return NotFound();
			}
			return await _dbContext.Movies.ToListAsync();
		}

		// GET: api/Movies/3
		[HttpGet("{id}")]
		public async Task<ActionResult<Movie>> GetMovie()
		{
			if (_dbContext.Movies == null)
			{
				return NotFound();
			}
			var movie = await _dbContext.Movies.FindAsync();
			if (movie == null)
			{
				return NotFound();
			}
			return movie;
		}
	}
}
