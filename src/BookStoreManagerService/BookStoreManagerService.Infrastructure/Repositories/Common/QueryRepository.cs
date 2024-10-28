using BookStoreManagerService.Domain.Repository.Common;
using BookStoreManagerService.Infrastructure.DataContext.Common;

namespace BookStoreManagerService.Infrastructure.Repositories.Common;

public class QueryRepository<TEntity>(string connectionString) : DbConnector(connectionString), IQueryRepository<TEntity>
    where TEntity : class
{
}
