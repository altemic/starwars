using Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class DI
    {
        public static void RegisterBusiness(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IFilmsService, FilmsService>();
            serviceCollection.AddTransient<IRatingService, RatingService>();
        }
    }
}
