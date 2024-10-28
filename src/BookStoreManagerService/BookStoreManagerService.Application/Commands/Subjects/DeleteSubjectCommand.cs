using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Subjects;

public class DeleteSubjectCommand : IRequest<OperationResult>
{
    public int[] Ids { get; }

    public DeleteSubjectCommand(int[] ids)
    {
        Ids = ids;
    }
}
