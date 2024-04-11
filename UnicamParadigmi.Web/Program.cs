using Microsoft.EntityFrameworkCore;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Middlewares;
using UnicamParadigmi.Application.Services;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// INIZIALIZZO I SERVICES

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext< MyDbContext>(conf =>
{
    conf.UseSqlServer("data source=localhost; Initial catalog=Paradigmi; User Id=AdParadigmi; Password=AdParadigmi; TrustServerCertificate=True");
});
builder.Services.AddScoped< ILibroService , LibroService >();
builder.Services.AddScoped<LibroRepository>();
var app = builder.Build();

//INIZIALIZZO I MIDDLEWARE

app.UseMiddleware<MiddlewareExample>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (HttpContext context, Func<Task> next) => {
    await next.Invoke();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
