using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Subjects;

public class CreateSubjectCommand : IRequest<OperationResult>
{
    public string Description { get; }

    public CreateSubjectCommand(string description)
    {
        Description = description;
    }
}
