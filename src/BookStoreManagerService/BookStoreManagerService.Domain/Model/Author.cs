using BookStoreManagerService.Domain.Common;

namespace BookStoreManagerService.Domain.Model;

public class Author : EntityBase<Author>
{
    private readonly List<Book> _books;

    public string Name { get; protected set; }
    public virtual IReadOnlyCollection<Book> Books => _books;

    public Author(string name)
    {
        Name = name;
    }

    public static Author Create(string name)
    {
        return new(name);
    }

    public void ChangeName(string name)
    {
        Name = name;
    }
}
