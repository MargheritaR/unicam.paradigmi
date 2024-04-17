using FluentValidation;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Services;

namespace UnicamParadigmi.Application.Extension;
public static class ServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies()
    .SingleOrDefault(assembly => assembly.GetName().Name == "UnicamParadigmi.Application"));
        services.AddScoped<ILibroService, LibroService>();
        services.AddScoped<ITokenService, TokenServices>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IUtenteService, UtenteService>();

        return services;
    }
}

