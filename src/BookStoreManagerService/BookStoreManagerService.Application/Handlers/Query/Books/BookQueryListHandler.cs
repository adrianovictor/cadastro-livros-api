using BookStoreManagerService.Application.Queries.Books;
using BookStoreManagerService.Application.Responses;
using BookStoreManagerService.Domain.Repository.Queries;
using MediatR;

namespace BookStoreManagerService.Application.Handlers.Query.Books;

public class BookQueryListHandler : IRequestHandler<QueryBooks, List<BookResponse>>
{
    private readonly IBookQueryRepository _bookRepository;

    public BookQueryListHandler(IBookQueryRepository bookQueryRepository)
    {
        _bookRepository = bookQueryRepository;
    }

    public async Task<List<BookResponse>> Handle(QueryBooks request, CancellationToken cancellationToken)
    {
        var bookList = await _bookRepository.GetAllAsync();

        if (bookList == null)
        {
            return [];
        }

        return bookList.Select(book => new BookResponse{
            Id = book.Id,
            Title = book.Title,
            Publisher = book.Publisher,
            Edition = book.Edition,
            AuthorId = book.AuthorId,
            Author = book.Author,
            YearOfPublication = book.YearOfPublication,
            SubjectId = book.SubjectId,
            Subject = book.Subject
        }).ToList();
    }
}
