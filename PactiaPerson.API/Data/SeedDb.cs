using PactiaPerson.Shared.Entities;

namespace PactiaPerson.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        //se hace la inyeccion para la base de datos
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        // se crea el metodo para inicializar la base de datos con algunos registros
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPersonAsync();
        }

        //este metodo valida si hay datos en la bd sino los crea
        private async Task CheckPersonAsync()
        {
            if(!_context.Persons.Any()) 
            {
                _context.Persons.Add(new Person { Cedula = "9034543468", Nombre = "Enrique", Apellido = "Benitez" });
                _context.Persons.Add(new Person { Cedula = "7834562309", Nombre = "Camila", Apellido = "Ordoñez" });
                _context.Persons.Add(new Person { Cedula = "2145358725", Nombre = "Lorena", Apellido = "Moncada" });
                _context.Persons.Add(new Person { Cedula = "1739347653", Nombre = "JR", Apellido = "Lopez" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
