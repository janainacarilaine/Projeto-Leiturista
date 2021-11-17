using Business.Interfaces;
using Business.Interfaces.Repositorios;
using Business.Interfaces.Servicos;
using Business.Notificacoes;
using Business.Servicos;
using Data.Repositorios;
using LeituristaAtualizado;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Config
{
    public static class DependenciasConfig
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();

            services.AddScoped<ILeituristaRepositorio, LeituristaRepositorio>();
            services.AddScoped<ILeituristaServico, LeituristaServico>();

            services.AddScoped<IOcorrenciaRepositorio, OcorrenciaRepositorio>();
            services.AddScoped<IOcorrenciaServico, OcorrenciaServico>();

            services.AddScoped<ILeituraRepositorio, LeituraRepositorio>();
            services.AddScoped<ILeituraServico, LeituraServico>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ITokenServico, TokenServico>();

            return services;
        }
    }
}
