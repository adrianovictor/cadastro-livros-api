using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Domain.Repository.Common;

namespace BookStoreManagerService.Domain.Repository.Commands;

public interface IBookRepository : ICommandRepository<Book>
{
}
