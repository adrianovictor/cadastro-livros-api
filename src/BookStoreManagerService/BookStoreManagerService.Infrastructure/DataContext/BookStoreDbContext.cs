using System;
using BookStoreManagerService.Infrastructure.DataContext.Common;
using BookStoreManagerService.Infrastructure.Mappings.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStoreManagerService.Infrastructure.DataContext;

public class BookStoreDbContext(string connectionString) : BaseContext<BookStoreDbContext>(connectionString)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorMap());
        modelBuilder.ApplyConfiguration(new BookMap());
        modelBuilder.ApplyConfiguration(new SubjectMap());
    }
}
