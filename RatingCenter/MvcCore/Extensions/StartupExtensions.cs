using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Entities;
using Integrations;
using Microsoft.Extensions.DependencyInjection;

namespace MvcCore.Extensions
{
    public static class StartupExtensions
    {
        public static void RegisterMvcCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterIntegrations();
            serviceCollection.RegisterEntities();
            serviceCollection.RegisterBusiness();
        }
    }
}
