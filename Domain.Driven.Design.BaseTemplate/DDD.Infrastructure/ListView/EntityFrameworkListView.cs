using DDD.Application.Common.Pagination;
using DDD.Domain.Common.Specifications;
using DDD.Infrastructure.EntityFramework.Contexts;
using DDD.Infrastructure.ListView.Extensions.IQueruableExtensions;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.ListView
{
    public class EntityFrameworkListView<T> : IListview<T> where T : class
    {
        private readonly DbSet<T> entities;

        public EntityFrameworkListView(WeatherForecastDBContext context)
        {
            this.entities = context.Set<T>();
        }

        public async Task<ListViewResponse<T>> Get(ListViewRequest request, params ISpecification<T>[] specifications)
        {
            IQueryable<T> filteredEntities = this.entities;

            foreach (ISpecification<T> spec in specifications)
            {
                filteredEntities = filteredEntities.Where(spec.ToExpression());
            }

            return await this.GetPaginatedData(filteredEntities, request);
        }

        public async Task<ListViewResponse<T>> GetPaginatedData(IQueryable<T> entities, ListViewRequest request)
        {
            int totalItems = await entities.CountAsync();

            IEnumerable<T> data = await entities.Sort(request.OrderBy, request.Order)
                                                .Skip(request.Skip)
                                                .TakeOrAll(request.Top)
                                                .ToListAsync();

            return new ListViewResponse<T>(request.Skip, request.Top ?? totalItems, totalItems, data);
        }
    }
}
