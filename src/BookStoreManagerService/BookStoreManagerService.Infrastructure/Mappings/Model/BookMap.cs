using BookStoreManagerService.Domain.Enum;
using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Infrastructure.Mappings.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreManagerService.Infrastructure.Mappings.Model;

public class BookMap : EntityMap<Book>
{
    protected override void Map(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Livro");

        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).HasColumnName("Codl");
        builder.Property(_ => _.Title).HasMaxLength(40).IsUnicode(false).HasColumnName("Titulo");
        builder.Property(_ => _.Publisher).HasMaxLength(40).IsUnicode(false).HasColumnName("Editora");
        builder.Property(_ => _.Edition).IsUnicode(false).HasColumnName("Edicao");
        builder.Property(_ => _.Title).HasMaxLength(40).IsUnicode(false).HasColumnName("Titulo");
        builder.Property(_ => _.YearOfPublication).HasColumnName("AnoPublicacao");
        builder.Property(_ => _.Status).IsRequired().HasColumnName("Situacao").HasDefaultValue(Status.Active);

        builder.HasMany(_ => _.Authors).WithMany(_ => _.Books)
            .UsingEntity(
                joinEntityName: "Livro_Autor",
                configureRight: l => l.HasOne(typeof(Author)).WithMany().HasForeignKey("Autor_CodAu"),
                configureLeft: r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("Livro_Codl"),
                configureJoinEntityType: j => j.ToTable("Livro_Autor").HasKey("Livro_Codl", "Autor_CodAu")
            );

        builder.HasMany(_ => _.Subjects).WithMany(_ => _.Books)
            .UsingEntity(
                joinEntityName: "Livro_Assunto",
                configureRight: l => l.HasOne(typeof(Subject)).WithMany().HasForeignKey("Assunto_CodAs"),
                configureLeft: r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("Livro_Codl"),
                configureJoinEntityType: j => j.ToTable("Livro_Assunto").HasKey("Livro_Codl", "Assunto_CodAs")
            );            
    }
}
