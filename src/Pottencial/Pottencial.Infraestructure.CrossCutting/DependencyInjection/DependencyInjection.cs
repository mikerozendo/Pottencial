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

        services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        return services;
    }
}
