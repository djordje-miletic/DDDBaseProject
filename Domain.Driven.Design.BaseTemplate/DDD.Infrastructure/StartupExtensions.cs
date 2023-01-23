using DDD.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

namespace DDD.Infrastructure
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDDDInfrastructure(this IServiceCollection services,
                                                Action<DbContextOptionsBuilder> dbContext)
        {
            services.AddMediatR(typeof(AssemblyReference), typeof(Application.AssemblyReference));

            services.AddEntityFrameworkServices(dbContext);

            return services;
        }
    }
}
