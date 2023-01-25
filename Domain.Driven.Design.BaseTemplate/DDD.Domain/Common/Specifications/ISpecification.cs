using System.Linq.Expressions;

namespace DDD.Domain.Common.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> ToExpression();
    }
}
