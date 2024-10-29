using BookStoreManagerService.Common.Extensions;
using BookStoreManagerService.Domain.Common;
using BookStoreManagerService.Infrastructure.Mappings.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStoreManagerService.Infrastructure.DataContext;

public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AuthorMap());
        modelBuilder.ApplyConfiguration(new BookMap());
        modelBuilder.ApplyConfiguration(new SubjectMap());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Save(async () =>
        {
            return await base.SaveChangesAsync(cancellationToken).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    // TODO: Adicionar log aqui
                }

                return task.Result;
            }, cancellationToken);
        });
    }

    protected virtual async Task<int> Save(Func<Task<int>> action)
    {
        int affectedRows;

        try
        {
            var entries = GetEntities();

            TraceAudit(entries);
            
            affectedRows = await action();

            await Task.CompletedTask;
        }
        catch (Exception)
        {
            // TODO: adicionar log aqui
            throw;
        }

        return affectedRows;
    }

    private IDictionary<object, EntityState> GetEntities()
    {
        return ChangeTracker.Entries()
            .Where(_ => _.State == EntityState.Added ||
                        _.State == EntityState.Modified ||
                        _.State == EntityState.Deleted ||
                        _.State == EntityState.Unchanged)
            .Select(_ => new { _.Entity, _.State })
            .DistinctBy(_ => _.Entity)
            .ToDictionary(_ => _.Entity, _ => _.State);
    }

    protected void TraceAudit(IDictionary<object, EntityState> entries)
    {
        entries.Where(_ => _.Value != EntityState.Unchanged).Each(entry =>
        {
            var auditEntity = entry.Key as IAuditing;

            if (entry.Value == EntityState.Added && auditEntity != null)
            {
                auditEntity.CreatedAt = DateTimeOffset.Now.UtcDateTime;
            }

            if (entry.Value == EntityState.Modified && auditEntity != null)
            {
                auditEntity.UpdatedAt = DateTimeOffset.Now.UtcDateTime;
            }
        });
    }

}
