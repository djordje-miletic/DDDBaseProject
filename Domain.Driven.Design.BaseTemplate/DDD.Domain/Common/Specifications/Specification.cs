using System.Linq.Expressions;

namespace DDD.Domain.Common.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = this.ToExpression().Compile();
            return predicate(entity);
        }

        protected Expression<Func<T, bool>> Or(Expression<Func<T, bool>> left,
                                               Expression<Func<T, bool>> right)
        {
            InvocationExpression invocationExpression = Expression.Invoke(right, left.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, invocationExpression), left.Parameters);
        }

        protected Expression<Func<T, bool>> And(Expression<Func<T, bool>> left,
                                                Expression<Func<T, bool>> right)
        {
            BinaryExpression andExpression = Expression.AndAlso(left.Body, right.Body);
            return Expression.Lambda<Func<T, bool>>(andExpression, left.Parameters.Single());
        }
    }
}
