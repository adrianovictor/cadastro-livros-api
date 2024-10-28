using BookStoreManagerService.Domain.Common;
using BookStoreManagerService.Domain.Repository.Common;
using BookStoreManagerService.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BookStoreManagerService.Infrastructure.Repositories.Common;

public class CommandRepository<TEntity>(BookStoreDbContext bookStoreDbContext) : ICommandRepository<TEntity>
    where TEntity : class, IEntityBase<TEntity>
{
    protected readonly BookStoreDbContext _context = bookStoreDbContext;

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task SaveAsync(TEntity entity, bool disableValidationOnSave = false)
    {
        if (entity.IsPersisted())
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        else
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        await _context.SaveChangesAsync();
    }
}
