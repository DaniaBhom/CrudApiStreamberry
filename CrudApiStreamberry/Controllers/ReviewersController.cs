using CrudApiStreamberry.Data;
using CrudApiStreamberry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApiStreamberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewersController : ControllerBase
    {
        private readonly DataContext _dbContext;
        private object asActionResult;

        public ReviewersController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Reviewers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reviewer>>> GetReviewers()
        {
            if (_dbContext.Reviewers == null)
            {
                return NotFound();
            }
            return await _dbContext.Reviewers.ToListAsync();
        }

        // GET: api/Reviewers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reviewer>> GetReviewers(int id)
        {
            if (_dbContext.Reviewers == null)
            {
                return NotFound();
            }
            var reviewer = await _dbContext.Reviewers.FindAsync(id);

            if (reviewer == null)
            {
                return NotFound();
            }
            return Ok(reviewer);
        }

        // POST: api/Reviewers
        [HttpPost]
        public async Task<ActionResult<Reviewer>> PostReviewer(Reviewer reviewer)
        {
            _dbContext.Reviewers.Add(reviewer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviewers), new { id = reviewer.ReviewerId }, reviewer);
        }

        // PUT: api/Reviewers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewer(int id, Reviewer reviewer)
        {
            if (id != reviewer.ReviewerId)
            {
                return BadRequest();
            }

            _dbContext.Entry(reviewer).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewerExists(id))
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



        // DELETE: api/Reviewers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewer(int id)
        {
            if (_dbContext.Reviewers == null)
            {
                return NotFound();
            }

            var reviewer = await _dbContext.Reviewers.FindAsync(id);
            if (reviewer == null)
            {
                return NotFound();
            }

            _dbContext.Reviewers.Remove(reviewer);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewerExists(long id)
        {
            return (_dbContext.Reviewers?.Any(e => e.ReviewerId == id)).GetValueOrDefault();
        }

    }

}


