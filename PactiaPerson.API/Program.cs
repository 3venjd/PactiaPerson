using Microsoft.EntityFrameworkCore;
using PactiaPerson.API.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexion a la bd 
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=SQLConnection"));

//inicializador del seeder
builder.Services.AddTransient<SeedDb>();

var app = builder.Build();

SeedData(app);

//debido a que no se puede inyectar por constructor debemos crear el metodo para implementar el seeder
void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory= app.Services.GetService<IServiceScopeFactory>();
    using (IServiceScope? scope = scopedFactory!.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
      .WithOrigins("http://localhost:4200", "https://localhost:44405")
      .AllowAnyMethod()
      .AllowAnyHeader()
    );

app.Run();
