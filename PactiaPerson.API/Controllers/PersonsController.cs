using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PactiaPerson.API.Data;
using PactiaPerson.Shared.Entities;

namespace PactiaPerson.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Persons.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return Ok(await _context.Persons.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Person person)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
            return Ok(await _context.Persons.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Remove(person);
            await _context.SaveChangesAsync();
            return Ok(await _context.Persons.ToListAsync());
        }
    }
}

