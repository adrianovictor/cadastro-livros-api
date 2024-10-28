using BookStoreManagerService.Domain.Common;
using BookStoreManagerService.Domain.Enum;
using BookStoreManagerService.Domain.Exceptions;

namespace BookStoreManagerService.Domain.Model;

public class Book : EntityBase<Book>
{
    private readonly List<Author> _authors = [];
    private readonly List<Subject> _subjects = [];

    public string Title { get; protected set; }
    public string Publisher { get; protected set; }
    public int Edition { get; protected set; }
    public string YearOfPublication { get; protected set; }
    public Status Status { get; protected set; }
    public decimal Price { get; protected set; }
    public int Quantity { get; protected set; }
    public virtual IReadOnlyCollection<Author> Authors => _authors;
    public virtual IReadOnlyCollection<Subject> Subjects => _subjects;

    public Book(string title, string publisher, int edition, string yearOfPublication, decimal price, int quantity, Status status = Status.Active)
    {
        Title = title;
        Publisher = publisher;
        Edition = edition;
        YearOfPublication = yearOfPublication;
        Price = price;
        Quantity = quantity;
        Status = status;
    }

    public static Book Create(string title, string publisher, int edition, string yearOfPublication, decimal price, int quantity, Status status = Status.Active)
    {
        return new (title, publisher, edition, yearOfPublication, price, quantity, status); 
    }

    public void ChangeTitle(string title)
    {
        Title = title;
    }

    public void ChangePublisher(string publisher)
    {
        Publisher = publisher;
    }

    public void ChangeEdition(int edition)
    {
        Edition = edition;
    }

    public void ChangeYearOfPublication(string yearOfPublication)
    {
        YearOfPublication = yearOfPublication;
    }

    public void AddAuthor(Author author)
    {
        if (!_authors.Exists(author.Equals))
        {
            _authors.Add(author);            
        }
    }

    public void RemoveAuthor(Author author)
    {
        if (_authors.Any(author.Equals))
        {
            _authors.Remove(author);
        }
    }

    public void AddSubject(Subject subject)
    {
        if (!_subjects.Exists(subject.Equals))
        {
            _subjects.Add(subject);
        }
    }

    public void RemoveSubject(Subject subject)
    {
        if (_subjects.Exists(subject.Equals))
        {
            _subjects.Remove(subject);
        }
    }    

    public void ChangeStatus(Status status)
    {
        if (Status == Status.Deleted)
        {
            throw new CannotChangeStatusOfADeletedEntityException();
        }

        Status = status;
    }
 
    public void ChangePrice(decimal price)
    {
        Price = price;
    }

    public void ChangeQuantity(int quantity)
    {
        Quantity = quantity;
    }
}
