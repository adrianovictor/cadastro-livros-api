using BookStoreManagerService.Domain.Common;

namespace BookStoreManagerService.Domain.Model;

public class Book : EntityBase<Book>
{
    private readonly List<Author> _authors = [];
    private readonly List<Subject> _subjects = [];

    public string Title { get; protected set; }
    public string Publisher { get; protected set; }
    public int Edition { get; protected set; }
    public string YearOfPublication { get; protected set; }
    public virtual IReadOnlyCollection<Author> Authors => _authors;
    public virtual IReadOnlyCollection<Subject> Subjects => _subjects;

    public Book(string title, string publisher, int edition, string yearOfPublication)
    {
        Title = title;
        Publisher = publisher;
        Edition = edition;
        YearOfPublication = yearOfPublication;
    }

    public static Book Create(string title, string publisher, int edition, string yearOfPublication)
    {
        return new (title, publisher, edition, yearOfPublication);
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
 
}
