using BookStoreManagerService.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreManagerService.Infrastructure.Mappings.Common;

public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntityBase<TEntity>
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(_ => _.CreatedAt).IsRequired().HasColumnName("DataCriacao");
        builder.Property(_ => _.UpdatedAt).IsRequired(false).HasColumnName("DataAtualizacao");

        Map(builder);
    }

    protected abstract void Map(EntityTypeBuilder<TEntity> builder);
}
