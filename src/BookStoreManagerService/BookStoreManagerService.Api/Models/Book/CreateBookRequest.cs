using System;

namespace BookStoreManagerService.Api.Models.Book;

public class CreateBookRequest
{
    public string Titulo { get; set; }
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; }
    public string Autor { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
