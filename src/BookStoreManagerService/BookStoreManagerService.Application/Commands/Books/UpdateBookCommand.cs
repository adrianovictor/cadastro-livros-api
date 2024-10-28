using BookStoreManagerService.Application.Responses;
using MediatR;

namespace BookStoreManagerService.Application.Commands.Books;

public class UpdateBookCommand : IRequest<OperationResult>
{
    public int Id { get; }
    public string Title { get; }
    public string Publisher { get; }
    public int Edition { get; }
    public string YearOfPublication { get; }
    public string Author { get; }
    public string Subject { get; }
    public decimal Price { get; }
    public int Quantity { get; }    

    public UpdateBookCommand(int id, string title, string publisher, int edition, string yearOfPublication, string author, string subject, decimal price, int quantity) 
    {
        Id = id;
        Title = title;        
        Publisher = publisher;
        Edition = edition;
        YearOfPublication = yearOfPublication;
        Author = author;
        Subject = subject;
        Price = price;
        Quantity = quantity;        
    }
}
