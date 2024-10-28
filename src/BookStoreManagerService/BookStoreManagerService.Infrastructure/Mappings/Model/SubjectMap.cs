using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Infrastructure.Mappings.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreManagerService.Infrastructure.Mappings.Model;

public class SubjectMap : EntityMap<Subject>
{
    protected override void Map(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Assunto");

        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).HasColumnName("CodAs");
        builder.Property(_ => _.Description).HasMaxLength(20).HasColumnName("Descricao").IsUnicode(false);
        builder.HasMany(_ => _.Books).WithMany(_ => _.Subjects);
    }
}
