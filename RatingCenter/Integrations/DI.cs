using System;
using System.Collections.Generic;
using System.Text;
using Integrations.StarWars;
using Microsoft.Extensions.DependencyInjection;

namespace Integrations
{
    public static class DI
    {
        public static void RegisterIntegrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IStarWarsClient, StarWarsClient>();
        }
    }
}
