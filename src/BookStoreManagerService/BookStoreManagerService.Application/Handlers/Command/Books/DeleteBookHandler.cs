using BookStoreManagerService.Application.Commands.Books;
using BookStoreManagerService.Application.Responses;
using BookStoreManagerService.Common.Extensions;
using BookStoreManagerService.Domain.Repository.Commands;
using MediatR;
using static BookStoreManagerService.Application.Responses.OperationResult;

namespace BookStoreManagerService.Application.Handlers.Command.Books;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, OperationResult>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<OperationResult> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var books = _bookRepository.GetAll().Where(_ => request.Ids.Contains(_.Id));
        if (!books.Any())
        {
            var error = new OperationErrorMessage
            {
                ErrorCode = "404",
                Message = "Livro não encontrado."
            };

            return new OperationResult
            {
                StatusCode = System.Net.HttpStatusCode.Conflict,
                Errors = [error]
            };
        }

        books.Each(async book => await _bookRepository.DeleteAsync(book));

        return new OperationResult
        {
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
