using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FOA.BACKEND.DataAccess.Repositories;

internal class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class
{
    protected FOAContext DbContext { get; set; }

    public BaseRepository(FOAContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IQueryable<TEntity> GetAll()
    {
        return DbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
    {
        return GetAll().Where(filter);
    }

    public IQueryable<TEntity> GetByFilter(
        Expression<Func<TEntity, bool>> filter,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy
    )
    {
        var filteredBusinessTrips = GetByFilter(filter);
        if (orderBy != null)
        {
            return orderBy(filteredBusinessTrips);
        }
        return filteredBusinessTrips;
    }

    public async Task<TEntity> GetByIdAsync(TId id)
    {
        return await DbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await DbContext.Set<TEntity>().AddRangeAsync(entities);
        await DbContext.SaveChangesAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await DbContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task RemoveAsync(TId id)
    {
        TEntity entity = await DbContext.Set<TEntity>().FindAsync(id);

        if (entity != null)
            DbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entityToUpdate)
    {
        if (entityToUpdate == null)
            throw new ArgumentNullException(nameof(entityToUpdate));

        DbContext.Set<TEntity>().Attach(entityToUpdate);
        DbContext.Entry(entityToUpdate).State = EntityState.Modified;
    }
}