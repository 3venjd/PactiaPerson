using Microsoft.AspNetCore.Mvc;
using PactiaPerson.API.Services;
using PactiaPerson.Shared.Entities;


namespace PactiaPerson.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IFirebaseApiConsume _context;

        public PersonsController(IFirebaseApiConsume context)
        {
            _context = context;
        }

        //metodo get para traer la lista de personas
        [HttpGet]
        public async Task<ActionResult> GetAsync() => Ok(await _context.GetAllRecordsAsync());

        
        //metodo post para crear un usuario
        [HttpPost]
        public async Task<ActionResult> PostAsync(Person person)
        {
            return Ok(await _context.AddRecordAsync(person, person.Id));
        }

        //metodo put para actualizar un usuario
        [HttpPut]
        public async Task<ActionResult> PutAsync(Person person)
        {
            return Ok(await _context.UpdateRecordAsync(person, person.Id));
        }

        //metodo delete para borrar un usuario
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return Ok(await _context.DeleteRecordAsync<string>(id));
        }
    }
}

