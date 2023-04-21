using Api.Peliculas.Data;
using Api.Peliculas.IRepository;
using Api.Peliculas.IServices;
using Api.Peliculas.Logic;
using Api.Peliculas.Repository;
using Api.Peliculas.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ExtensionServices
    {
        public static IServiceCollection AddUsuarioServices([NotNullAttribute] this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<UsuarioLogic, UsuarioLogic>();

            services.AddDbContext<PeliculasContext>(ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddPeliculaServices([NotNullAttribute] this IServiceCollection services)
        {
            services.AddScoped<IPeliculaService, PeliculaService>();
            services.AddScoped<IPeliculaRepository, PeliculaRepository>();
            services.AddScoped<PeliculaLogic, PeliculaLogic>();

            services.AddDbContext<PeliculasContext>(ServiceLifetime.Transient);

            return services;
        }
    }
}
