
using UnicamParadigmi.Application.Extension;
using UnicamParadigmi.Application.Middlewares;
using UnicamParadigmi.Models.Extension;
using UnicamParadigmi.Web.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// INIZIALIZZO I SERVICES
builder.Services.AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration).AddWebServices(builder.Configuration);
var app = builder.Build();

//INIZIALIZZO I MIDDLEWARE
app.AddWebMiddleware();
app.UseMiddleware<MiddlewareExtension>();


app.Run();
