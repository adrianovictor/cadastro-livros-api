using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Domain.Repository.Commands;
using BookStoreManagerService.Infrastructure.DataContext;
using BookStoreManagerService.Infrastructure.Repositories.Common;

namespace BookStoreManagerService.Infrastructure.Repositories.Commands;

public class BookCommandRepository(BookStoreDbContext context) : CommandRepository<Book>(context), IBookRepository
{
}
