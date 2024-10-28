using System;
using BookStoreManagerService.Application.Commands.Authors;
using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Handlers.Command.Authors;

public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, OperationResult>
{
    public Task<OperationResult> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
