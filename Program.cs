using Ui.Controllers.Extensions;
using Microsoft.Extensions.Configuration;
using DataAcces.ModelsDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
// recuperar secreto de conexion a la base de datos y crear una unica instancia
var connection = builder.Configuration["ConnectionStrings:DefaultConnection"] ?? "";
builder.Services.AddSingleton(connection);
// Add jwt 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options => { options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "",
            ValidAudience = "",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AKIAU3S75QKKR6PATVOAFDGCVSGDSDRJHDFHDFHSDTS"))
        };
        });

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

