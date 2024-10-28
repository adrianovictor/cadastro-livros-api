using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Authors;

public class DeleteAuthorCommand : IRequest<OperationResult>
{
    public int[] Ids { get; }

    public DeleteAuthorCommand(int[] ids)
    {
        Ids = ids;
    }
}
