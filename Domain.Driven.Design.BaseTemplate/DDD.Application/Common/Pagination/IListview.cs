using DDD.Domain.Common.Specifications;

namespace DDD.Application.Common.Pagination
{
    public interface IListview<T>
    {
        Task<ListViewResponse<T>> Get(ListViewRequest request, params ISpecification<T>[] specifications);
    }
}
