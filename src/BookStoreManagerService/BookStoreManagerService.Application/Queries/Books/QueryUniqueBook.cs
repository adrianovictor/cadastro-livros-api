using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Queries.Books;

public class QueryUniqueBook : QuerySearch, IRequest<BookResponse>
{
    public int? Id { get; set; }
}