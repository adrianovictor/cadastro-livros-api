using BookStoreManagerService.Application.Queries.Books;
using BookStoreManagerService.Application.Responses;
using BookStoreManagerService.Domain.Repository.Queries;
using MediatR;

namespace BookStoreManagerService.Application.Handlers.Query.Books;

public class BookUniqueQueryHandler : IRequestHandler<QueryUniqueBook, BookResponse>
{
    private readonly IBookQueryRepository _bookRepository;

    public BookUniqueQueryHandler(IBookQueryRepository bookQueryRepository)
    {
        _bookRepository = bookQueryRepository;
    }    
    public async Task<BookResponse> Handle(QueryUniqueBook request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync((int)request.Id!);

        if (book == null)
        {
            return default!;
        }

        return new BookResponse{
            Id = book.Id,
            Title = book.Title,
            Publisher = book.Publisher,
            Edition = book.Edition,
            AuthorId = book.AuthorId,
            Author = book.Author,
            YearOfPublication = book.YearOfPublication,
            Subject = book.Subject,
            SubjectId = book.SubjectId
        };
    }
}
