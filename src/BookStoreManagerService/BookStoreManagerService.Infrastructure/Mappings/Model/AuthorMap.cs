using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Infrastructure.Mappings.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreManagerService.Infrastructure.Mappings.Model;

public class AuthorMap : EntityMap<Author>
{
    protected override void Map(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Autor");

        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).HasColumnName("CodAu");  
        builder.Property(_ => _.Name).HasMaxLength(40).IsUnicode(false).HasColumnName("Nome");
        builder.HasMany(_ => _.Books).WithMany(_ => _.Authors);
    }
}
