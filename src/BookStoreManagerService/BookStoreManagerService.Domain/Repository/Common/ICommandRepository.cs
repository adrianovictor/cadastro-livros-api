using BookStoreManagerService.Domain.Common;

namespace BookStoreManagerService.Domain.Repository.Common;

public interface ICommandRepository<TEntity>
    where TEntity : class, IEntityBase<TEntity>
{
    IQueryable<TEntity> GetAll();
    Task SaveAsync(TEntity entity, bool disableValidationOnSave = false);
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}

