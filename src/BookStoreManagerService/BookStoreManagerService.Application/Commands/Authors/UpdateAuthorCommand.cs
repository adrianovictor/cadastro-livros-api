using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Authors;

public class UpdateAuthorCommand : IRequest<OperationResult>
{
    public int Id { get; }
    public string Name { get; }

    public UpdateAuthorCommand(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
