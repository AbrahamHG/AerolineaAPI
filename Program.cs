using AerolineaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AerolineaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sql_connection"), sqlServerOptionsAction: sqloption =>
{
    sqloption.EnableRetryOnFailure(maxRetryCount: 20,
       maxRetryDelay: TimeSpan.FromSeconds(15),
       errorNumbersToAdd: null);

})

);

builder.Services.AddCors(option => option.AddPolicy("AllowAnyOrigin" //anadimos una nueva politica
    , builder => builder.AllowAnyOrigin() //indicamos que la politica acepta cualquier origen
.AllowAnyMethod() //indicamos que la politica acepta cualquier metodo
.AllowAnyHeader() //indicamos que la politica acepte cualquier cabecera
));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// indicamos que la aplicacion utilice nuestra politica de CORS
app.UseCors("AllowAnyOrigin");


app.UseAuthorization();

app.MapControllers();

app.Run();
