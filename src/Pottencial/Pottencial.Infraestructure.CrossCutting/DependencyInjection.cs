using Microsoft.Extensions.DependencyInjection;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Services;
using Pottencial.Domain.Interfaces.Services;
using Pottencial.Domain.Services;
using Pottencial.Infraestructure.Data.Repositories;

namespace Pottencial.Infraestructure.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaAppService, PessoaAppService>();
            return services;
        }
    }
}
