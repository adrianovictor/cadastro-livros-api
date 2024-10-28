using System;
using BookStoreManagerService.Application.Commands.Subjects;
using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Handlers.Command.Subjects;

public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectCommand, OperationResult>
{
    public Task<OperationResult> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
