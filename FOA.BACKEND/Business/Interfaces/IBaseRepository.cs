using System.Linq.Expressions;

namespace FOA.BACKEND.Business.Interfaces;

public interface IBaseRepository<TEntity, TId> where TEntity : class
{
    IQueryable<TEntity> GetAll();

    Task<TEntity> GetByIdAsync(TId id);

    IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);

    IQueryable<TEntity> GetByFilter(
        Expression<Func<TEntity, bool>> filter,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy
    );

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    Task AddAsync(TEntity entity);

    Task RemoveAsync(TId id);

    void Update(TEntity entityToUpdate);
}