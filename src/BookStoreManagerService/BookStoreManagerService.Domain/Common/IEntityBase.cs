namespace BookStoreManagerService.Domain.Common;

public interface IEntityBase<in TEntity> : IAuditing
    where TEntity : class
{
    int Id { get; }
    bool IsPersisted();
}
