using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Semaphoria.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSemaphoria(this IServiceCollection services)
        {
            services.TryAddSingleton<ISemaphoreManager, SemaphoreManager>();
            return services;
        }
    }
}
