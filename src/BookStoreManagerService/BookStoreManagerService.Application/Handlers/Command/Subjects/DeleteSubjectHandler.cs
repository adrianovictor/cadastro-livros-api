using System;
using BookStoreManagerService.Application.Commands.Subjects;
using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Handlers.Command.Subjects;

public class DeleteSubjectHandler : IRequestHandler<DeleteSubjectCommand, OperationResult>
{
    public Task<OperationResult> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
