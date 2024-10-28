using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Queries.Books;

public class QueryBooks : QuerySearch, IRequest<List<BookResponse>>
{
}

