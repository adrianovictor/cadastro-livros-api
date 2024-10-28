using System;
using BookStoreManagerService.Application.Commands.Authors;
using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Handlers.Command.Authors;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, OperationResult>
{
    public Task<OperationResult> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
