using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Books;

public class DeleteBookCommand : IRequest<OperationResult>
{
    public int[] Ids { get; }

    public DeleteBookCommand(int[] ids)
    {
        Ids = ids;
    }
}
