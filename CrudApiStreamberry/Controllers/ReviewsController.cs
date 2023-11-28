using CrudApiStreamberry.Data;
using CrudApiStreamberry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApiStreamberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly DataContext _dbContext;
        private object asActionResult;

        public ReviewsController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            if (_dbContext.Reviews == null)
            {
                return NotFound();
            }
            return await _dbContext.Reviews.ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviews(int id)
        {
            if (_dbContext.Reviews == null)
            {
                return NotFound();
            }
            var review = await _dbContext.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviews), new { id = review.ReviewId }, review);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            _dbContext.Entry(review).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            if (_dbContext.Reviews == null)
            {
                return NotFound();
            }

            var review = await _dbContext.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(long id)
        {
            return (_dbContext.Reviews?.Any(e => e.ReviewId == id)).GetValueOrDefault();
        }

    }

}


