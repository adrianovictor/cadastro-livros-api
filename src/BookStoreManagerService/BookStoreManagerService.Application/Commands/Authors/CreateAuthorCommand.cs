using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Authors;

public class CreateAuthorCommand : IRequest<OperationResult>
{
    public string Name { get; }

    public CreateAuthorCommand(string name)
    {
        Name = name;
    }
}
