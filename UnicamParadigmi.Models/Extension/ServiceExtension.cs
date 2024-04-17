using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Context;
using Microsoft.Extensions.Configuration;
using UnicamParadigmi.Models.Repositories;

namespace UnicamParadigmi.Models.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(config.GetConnectionString("MyDbContext"));
            });
            services.AddScoped<LibroRepository>();
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<UtenteRepository>();

            return services;
        }
    }
}
