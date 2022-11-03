using System.Collections.Immutable;
using System.Linq.Expressions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Abstractions;

public class BaseRepository<TModel, TDbContext> : IBaseRepository<TModel> 
    where TModel : ModelBase
    where TDbContext : DbContext
{
    
    private readonly TDbContext _context;
    private DbSet<TModel> _dbset;

    protected IList<Expression<Func<TModel, object>>> IncludeProperties = new List<Expression<Func<TModel, object>>>();
    
    public BaseRepository(TDbContext dbContext)
    {
        _context = dbContext;
        _dbset = _context.Set<TModel>();
    }
    
    public async Task AddAsync(TModel model)
    {
        model.ExternalId = Guid.NewGuid();
        model.CreatedAt = DateTime.UtcNow;
        
        await _dbset.AddAsync(model);
    }

    public async Task UpdateAsync(TModel model)
    {
        if (await HasAnyAsync(px => px.Id.Equals(model.Id)))
            _dbset.Update(model);
    }

    public async Task DeleteAsync(Guid externalId)
    {
        var modelToRemove = await FindByPredicateAsync(px => px.ExternalId.Equals(externalId));
        
        if (modelToRemove != default)
            _dbset.Remove(modelToRemove);
    }

    public async Task<bool> HasAnyAsync(Expression<Func<TModel, bool>> predicate)
    {
        return await _dbset
            .Where(predicate)
            .AnyAsync();
    }

    public async Task<int> CountAsync(Expression<Func<TModel, bool>> predicate)
    {
        return await _dbset.CountAsync(predicate);
    }

    public async Task<TModel?> FindByPredicateAsync(Expression<Func<TModel, bool>> predicate)
    {
        var queryable = _dbset.Where(predicate);
        queryable = IncludeProperties?
            .Aggregate(queryable, 
                (current, expression) => current.Include(expression));

        return await queryable.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TModel>> ListByPredicateAsync(Expression<Func<TModel, bool>> predicate)
    {
        var queryable = _dbset.Where(predicate);
        queryable = IncludeProperties?
            .Aggregate(queryable, 
                (current, expression) => current.Include(expression));

        return await queryable.ToListAsync();
    }
    
    public async Task<(int pageNumber, int pageSize, int lastPage, IReadOnlyCollection<TModel?>)> ListPaginatedAsync(Expression<Func<TModel, bool>> predicate, int pageNumber, int pageSize)
    {
        var count = await CountAsync(predicate);

        if(count == 0) 
            return (pageNumber, pageSize, 1, ImmutableList<TModel?>.Empty);

        var queryable = _dbset
            .Where(predicate)
            .OrderBy(px => px.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        queryable = IncludeProperties?
            .Aggregate(queryable, 
                (current, expression) => current.Include(expression));
            
        
        var elements = await queryable
            .ToListAsync();
        
        var totalPages = (int) count / pageSize;
        if (count % pageSize != 0) 
            totalPages++;

        return (pageNumber, pageSize, totalPages, elements);
    }
}