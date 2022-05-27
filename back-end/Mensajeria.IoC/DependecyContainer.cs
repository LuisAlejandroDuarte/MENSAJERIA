using Mensajeria.Controllers;
using Mensajeria.Presenter;
using Mensajeria.RepositoryEFCore;
using Mensajeria.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Mensajeria.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddMensajeriaDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices(configuration);
            services.AddPresenters();
            services.AddHttpContext();

            return services;
        }
    }
}
