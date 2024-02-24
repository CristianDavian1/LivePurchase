using Ui.Controllers.Extensions;
using Microsoft.Extensions.Configuration;
using DataAcces.ModelsDb;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);
// recuperar secreto de conexion a la base de datos
var connection = builder.Configuration["ConnectionStrings:DefaultConnection"] ?? "";
builder.Services.AddSingleton(connection);

//Añadir servicios al contenedor con dependencias
builder.IncludeDomain();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add controllers and related services
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
