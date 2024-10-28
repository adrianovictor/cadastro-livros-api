using BookStoreManagerService.Application.Commands.Books;
using BookStoreManagerService.Application.Responses;
using BookStoreManagerService.Common.Extensions;
using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Domain.Repository.Commands;
using MediatR;
using static BookStoreManagerService.Application.Responses.OperationResult;

namespace BookStoreManagerService.Application.Handlers.Command.Books;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, OperationResult>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ISubjectRepository _subjectRepository;
    
    public UpdateBookHandler(IAuthorRepository authorRepository, IBookRepository bookRepository, ISubjectRepository subjectRepository)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
        _subjectRepository = subjectRepository;
    }

    public async Task<OperationResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var book = _bookRepository
                .GetAll()
                .Eager(_ => _.Authors)
                .Eager(_ => _.Subjects)
                .FirstOrDefault(_ => _.Id == request.Id);

            if (book != null)
            {
                var author = _authorRepository.GetAll().FirstOrDefault(_ => _.Name == request.Author);
                author ??= Author.Create(request.Author);

                var subject = _subjectRepository.GetAll().FirstOrDefault(_ => _.Description == request.Subject);
                subject ??= Subject.Create(request.Subject);

                book.ChangeTitle(request.Title);
                book.ChangeEdition(request.Edition);
                book.ChangeYearOfPublication(request.YearOfPublication);
                book.AddAuthor(author!);
                book.AddSubject(subject);

                await _bookRepository.SaveAsync(book);

                return new OperationResult
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            else
            {
                var error = new OperationErrorMessage
                {
                    ErrorCode = "404",
                    Message = "Livro não encontrado."
                };

                return new OperationResult
                {
                    StatusCode = System.Net.HttpStatusCode.Conflict,
                    Errors = [error]
                };
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
