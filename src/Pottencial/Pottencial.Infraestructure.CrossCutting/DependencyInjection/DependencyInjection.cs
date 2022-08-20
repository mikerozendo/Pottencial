using Microsoft.Extensions.DependencyInjection;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Services;
using Pottencial.Domain.Interfaces.Repositories;
using Pottencial.Domain.Interfaces.Services;
using Pottencial.Domain.Services;
using Pottencial.Infraestructure.CrossCutting.JWT;
using Pottencial.Infraestructure.CrossCutting.JWT.Interfaces;
using Pottencial.Infraestructure.Data.Repositories;

namespace Pottencial.Infraestructure.CrossCutting.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();

        services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
        services.AddSingleton<IVendedorRepository, VendedorRepository>();
        services.AddSingleton<IVendaAppService, VendaAppService>();

        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IVendedorService, VendedorService>();
        services.AddScoped<IVendaService, VendaService>();

        services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        services.AddScoped<IVendedorAppService, VendedorAppService>();
        services.AddScoped<IVendaRepository, VendaRepository>();

        return services;
    }
}
