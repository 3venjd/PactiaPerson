using Microsoft.EntityFrameworkCore;
using PactiaPerson.API.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexion a la bd 
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=SQLConnection"));

var app = builder.Build();

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
