using System;
using BookStoreManagerService.Application.Commands.Subjects;
using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Handlers.Command.Subjects;

public class CreateSubjectHandler : IRequestHandler<CreateSubjectCommand, OperationResult>
{
    public Task<OperationResult> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
