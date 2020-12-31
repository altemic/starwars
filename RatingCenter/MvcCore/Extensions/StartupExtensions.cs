using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Integrations;
using Microsoft.Extensions.DependencyInjection;
using MvcCore.Services;

namespace MvcCore.Extensions
{
    public static class StartupExtensions
    {
        public static void RegisterMvcCore(this IServiceCollection serviceCollection)
        {
            #region ExternalDependencies
            serviceCollection.RegisterIntegrations();
            serviceCollection.RegisterEntities();
            #endregion

            #region InternalDependencies
            serviceCollection.AddTransient<IFilmsService, FilmsService>();
            #endregion
        }
    }
}
