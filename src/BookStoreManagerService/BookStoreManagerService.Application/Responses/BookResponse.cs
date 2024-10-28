namespace BookStoreManagerService.Application.Responses;

public class BookResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int Edition { get; set; }
    public string YearOfPublication { get; set; }
    public int AuthorId { get; set; }
    public string Author { get; set; }
    public int SubjectId { get; set; }
    public string Subject { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
