using Microsoft.AspNetCore.Mvc;
using PactiaPerson.API.Services;
using PactiaPerson.Shared.Entities;
using System;


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
        public async Task<ActionResult> GetAsync() {

            var result = await _context.GetAllRecordsAsync<Person>();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRecordAsync(int id)
        {
           return Ok(await _context.GetRecordAsync<Person>(id));
        }

        //metodo post para crear un usuario
        [HttpPost]
        public async Task<ActionResult> PostAsync(Person person)
        {

            if (await _context.GetRecordAsync<Person>(person.id) == null)
            {
                var register = await _context.GetAllRecordsAsync<Person>();
                var LastId = register.IndexOf(null!);
                person.id = LastId;
                await _context.AddRecordAsync(person, LastId);
                return Ok(await _context.GetAllRecordsAsync<Person>());
            }

            return NotFound();
        }

        //metodo put para actualizar un usuario
        [HttpPut]
        public async Task<ActionResult> PutAsync(Person person)
        {

            if (await _context.GetRecordAsync<Person>(person.id) != null)
            {
                await _context.UpdateRecordAsync(person, person.id);
                return Ok(await _context.GetAllRecordsAsync<Person>());
            }

            return NotFound();
        }

        //metodo delete para borrar un usuario
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (await _context.GetRecordAsync<Person>(id) != null)
            {
                await _context.DeleteRecordAsync<Person>(id);
                return Ok(await _context.GetAllRecordsAsync<Person>());
            }
            return NotFound();
        }
    }
}

