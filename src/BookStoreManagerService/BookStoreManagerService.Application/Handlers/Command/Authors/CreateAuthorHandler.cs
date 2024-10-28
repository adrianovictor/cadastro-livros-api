using System;
using BookStoreManagerService.Application.Commands.Authors;
using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Handlers.Command.Authors;

public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, OperationResult>
{
    public Task<OperationResult> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
