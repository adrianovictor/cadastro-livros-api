using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Subjects;

public class UpdateSubjectCommand : IRequest<OperationResult>
{
    public int Id { get; }
    public string Description { get; }

    public UpdateSubjectCommand(string description)
    {
        Description = description;
    }
}
