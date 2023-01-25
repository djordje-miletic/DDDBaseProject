using DDD.Application.Common.Pagination;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure.ListView.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddGenericEFListView(this IServiceCollection services)
        {
            services.AddTransient(typeof(IListview<>), typeof(EntityFrameworkListView<>));
            return services;
        }
    }
}
