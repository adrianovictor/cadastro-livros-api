using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Domain.Repository.Commands;
using BookStoreManagerService.Infrastructure.DataContext;
using BookStoreManagerService.Infrastructure.Repositories.Common;

namespace BookStoreManagerService.Infrastructure.Repositories.Commands;

public class AuthorCommandRepository(BookStoreDbContext context) : CommandRepository<Author>(context), IAuthorRepository
{

}
