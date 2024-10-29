using BookStoreManagerService.Application.Commands.Books;
using BookStoreManagerService.Application.Responses;
using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Domain.Repository.Commands;
using MediatR;
using static BookStoreManagerService.Application.Responses.OperationResult;

namespace BookStoreManagerService.Application.Handlers.Command.Books;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, OperationResult>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IBookRepository _bookRepository;

    public CreateBookHandler(IAuthorRepository authorRepository, ISubjectRepository subjectRepository, IBookRepository bookRepository)
    {
        _authorRepository = authorRepository;
        _subjectRepository = subjectRepository;
        _bookRepository = bookRepository;
    }

    public async Task<OperationResult> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var book = _bookRepository.GetAll().FirstOrDefault(_ => _.Title == request.Title);
            if (book == null)
            {
                var author = _authorRepository.GetAll().FirstOrDefault(_ => _.Name == request.Author);
                author ??= Author.Create(request.Author);

                var subject = _subjectRepository.GetAll().FirstOrDefault(_ => _.Description == request.Subject);
                subject ??= Subject.Create(request.Subject);

                book = Book.Create(
                    request.Title, 
                    request.Publisher, 
                    request.Edition, 
                    request.YearOfPublication, 
                    request.Price, 
                    request.Quantity);
                book.AddAuthor(author!);
                book.AddSubject(subject);

                await _bookRepository.SaveAsync(book);

                return new OperationResult
                {
                    StatusCode = System.Net.HttpStatusCode.Created,
                    ResourceId = book.Id
                };
            }
            else
            {
                var error = new OperationErrorMessage
                {
                    ErrorCode = "400",
                    Message = "Livro j� registrado."
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
