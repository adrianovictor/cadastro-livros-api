using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Books;

public class CreateBookCommand : IRequest<OperationResult>
{
    public string Title { get; }
    public string Publisher { get; }
    public int Edition { get; }
    public string YearOfPublication { get; }
    public string Author { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public CreateBookCommand(string title, string publisher, int edition, string yearOfPublication, string author, decimal price, int quantity)
    {
        Title = title;        
        Publisher = publisher;
        Edition = edition;
        YearOfPublication = yearOfPublication;
        Author = author;
        Price = price;
        Quantity = quantity;
    }
}
