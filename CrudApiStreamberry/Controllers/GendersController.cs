using CrudApiStreamberry.Data;
using CrudApiStreamberry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApiStreamberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly DataContext _dbContext;
        private object asActionResult;

        public GendersController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            if (_dbContext.Genders == null)
            {
                return NotFound();
            }
            return await _dbContext.Genders.ToListAsync();
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGenders(int id)
        {
            if (_dbContext.Genders == null)
            {
                return NotFound();
            }
            var gender = await _dbContext.Genders.FindAsync(id);

            if (gender== null)
            {
                return NotFound();
            }
            return Ok(gender);
        }

        // POST: api/Genders
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender gender)
        {
            _dbContext.Genders.Add(gender);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGenders), new { id = gender.GenderId }, gender);
        }

        // PUT: api/Genders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(int id, Gender gender)
        {
            if (id != gender.GenderId)
            {
                return BadRequest();
            }

            _dbContext.Entry(gender).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(id))
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



        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            if (_dbContext.Genders == null)
            {
                return NotFound();
            }

            var gender = await _dbContext.Genders.FindAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            _dbContext.Genders.Remove(gender);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool GenderExists(long id)
        {
            return (_dbContext.Genders?.Any(e => e.GenderId == id)).GetValueOrDefault();
        }

    }

}


