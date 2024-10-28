using BookStoreManagerService.Domain.Common;

namespace BookStoreManagerService.Domain.Model;

public class Subject : EntityBase<Subject>
{
    private readonly List<Book> _books;

    public string Description { get; protected set; }
    public virtual IReadOnlyCollection<Book> Books => _books;

    public Subject(string Description)
    {
        this.Description = Description;
    }

    public static Subject Create(string description)
    {
        return new(description);
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }
}
