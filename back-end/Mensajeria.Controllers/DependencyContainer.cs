using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddHttpContext(this IServiceCollection services)
        {

            services.AddHttpContextAccessor();

            return services;

        }
    }
}
