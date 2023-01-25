using DDD.Application.Common.Pagination;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DDD.Infrastructure.ListView.Extensions.IQueruableExtensions
{
    public static class IQueriableExtensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string? columnName, SortOrder sortOrder)
        {
            PropertyInfo? pi = typeof(T).GetProperties()
                                        .Where(p => p.Name.Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                                        .DefaultIfEmpty(typeof(T).GetProperties().Where(p => p.Name == "Id").FirstOrDefault())
                                        .FirstOrDefault();

            if(pi is null)
            {
                return source;
            }

            columnName = pi.Name;

            string sortingDir = string.Empty;
            if(sortOrder == SortOrder.asc)
            {
                sortingDir = "OrderBy";
            }
            else if(sortOrder == SortOrder.desc)
            {
                sortingDir = "OrderByDescending";
            }

            ParameterExpression param = Expression.Parameter(typeof(T), columnName);

            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, columnName), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }

        public static IQueryable<T> TakeOrAll<T>(this IQueryable<T> source, int? takeNumber)
        {
            return takeNumber.HasValue ? source.Take(takeNumber.Value) : source;
        }
    }
}
