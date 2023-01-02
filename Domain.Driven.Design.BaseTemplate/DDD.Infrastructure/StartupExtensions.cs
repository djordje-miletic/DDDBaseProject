using DDD.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDDDInfrastructure(this IServiceCollection services,
                                                Action<DbContextOptionsBuilder> dbContext)
        {
            services.AddEntityFrameworkServices(dbContext);

            return services;
        }
    }
}
