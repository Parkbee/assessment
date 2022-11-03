using System.Linq.Expressions;
using Data.Models;

namespace Data.Repositories.Abstractions;

public interface IBaseRepository<TModel> where TModel : ModelBase
{
    Task AddAsync(TModel model);
    Task UpdateAsync(TModel model);
    Task DeleteAsync(Guid externalId);

    Task<bool> HasAnyAsync(Expression<Func<TModel, bool>> predicate);
    Task<int> CountAsync(Expression<Func<TModel, bool>> predicate);
    
    Task<TModel?> FindByPredicateAsync(Expression<Func<TModel, bool>> predicate);
    Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<TModel?>)> ListPaginatedAsync(
        Expression<Func<TModel, bool>> predicate, int pageNumber, int pageSize);
}