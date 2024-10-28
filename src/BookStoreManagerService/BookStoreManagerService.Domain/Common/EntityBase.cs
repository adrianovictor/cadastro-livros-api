using System;

namespace BookStoreManagerService.Domain.Common;

public abstract class EntityBase<TEntity> : IEntityBase<TEntity>
    where TEntity : class
{
    public virtual int Id { get; protected set; }    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public virtual bool IsPersisted()
    {
        return !IsTransient();
    }

    protected virtual bool IsTransient()
    {
        return Id == 0;
    }    
}
