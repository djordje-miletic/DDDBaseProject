using System.Linq.Expressions;

namespace DDD.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        Task<TEntity?> GetById(object id);

        Task Insert(TEntity entity);

        void Update(TEntity entityToUpdate);

        Task Delete(object id);

        void Delete(TEntity entityToDelete);
    }
}
