namespace BookStoreManagerService.Api.Models.Book;

public class CreateBookRequest
{
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int Edition { get; set; }
    public string YearOfPublication { get; set; }
    public string Author { get; set; }
    public string Subject { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
