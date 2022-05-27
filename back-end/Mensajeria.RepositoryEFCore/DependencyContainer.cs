using Mensajeria.Entities.Interfaces;
using Mensajeria.RepositoryEFCore.DataContext;
using Mensajeria.RepositoryEFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mensajeria.RepositoryEFCore
{
    public static class  DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MensajeriaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConectionString")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPropietarioRepository, PropietarioRepository>();
            services.AddScoped<IMotoRepository, MotoRepository>();
            services.AddScoped<ITurnoRepository, TurnoRepository>();
            services.AddScoped<IRutaRepository, RutaRepository>();

            services.AddScoped<IReporteRepository, ReporteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
            
        }
    }
}
