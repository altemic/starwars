using Microsoft.Extensions.DependencyInjection;

namespace Entities
{
    public static class DI
    {
        public static void RegisterEntities(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<FilmsContext>();
        }
    }
}
