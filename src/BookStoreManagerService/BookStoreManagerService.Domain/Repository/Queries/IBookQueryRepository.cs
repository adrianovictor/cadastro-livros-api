using BookStoreManagerService.Domain.Dto;
using BookStoreManagerService.Domain.Repository.Common;

namespace BookStoreManagerService.Domain.Repository.Queries;

public interface IBookQueryRepository : IQueryRepository<BookDto>
{
        Task<IReadOnlyList<BookDto>> GetAllAsync();

        Task<BookDto?> GetByIdAsync(int id);

        Task<BookDto?> GetByUniqueIdAsync(int uniqueId);

        Task<BookDto?> GetByIdentificationNumberAsync(string identificationNumber);
}
