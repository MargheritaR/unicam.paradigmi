using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
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
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies()
    .SingleOrDefault(assembly => assembly.GetName().Name == "UnicamParadigmi.Application"));

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseSqlServer("data source=localhost; Initial catalog=Paradigmi; User Id=AdParadigmi; Password=AdParadigmi; TrustServerCertificate=True");
});
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<LibroRepository>();
builder.Services.AddScoped<ITokenService, TokenServices>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        string key = "UnicamParadigmi.Chiave1234567890123";
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://paradigmi.unicam.it",
            IssuerSigningKey = securityKey
        };
    });
var app = builder.Build();

//INIZIALIZZO I MIDDLEWARE

app.UseMiddleware<MiddlewareExample>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (HttpContext context, Func<Task> next) =>
{
    await next.Invoke();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
