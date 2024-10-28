using System;
using BookStoreManagerService.Domain.Model;

namespace BookStoreManagerService.UnitTests.Domain.Model;

public class BookTest
{
    [Fact(DisplayName = "Constructor, when trying to create a book, should have a default values.")]
    public void Constructor_WhenTryingToCreateABook_ShouldHaveDefaultValues()
    {
        // arrage
        var book = Book.Create("Livro da Vida", "Editora Nova", 1, "2024");

        // asset
        Assert.Equal("Livro da Vida", book.Title);
        Assert.Equal("Editora Nova", book.Publisher);
        Assert.Equal(1, book.Edition);
        Assert.Equal("2024", book.YearOfPublication);
    }

    [Fact(DisplayName = "When trying to add a author, should have success.")]
    public void WhenTryingToAddAAuthor_ShouldHaveSuccess()
    {
        // arrange
        var author = Author.Create("John Wayne");
        var book = Book.Create("Livro da Vida", "Editora Nova", 1, "2024");

        // act
        book.AddAuthor(author);

        // assert
        Assert.Single(book.Authors);
    }

    [Fact(DisplayName = "When trying to remove an author, should have success.")]
    public void WhenTryingToRemoveAnAuthor_ShouldHaveSuccess()
    {
        // arrange
        var author = Author.Create("John Wayne");
        var book = Book.Create("Livro da Vida", "Editora Nova", 1, "2024");

        book.AddAuthor(author);

        // act
        book.RemoveAuthor(author);

        // assert
        Assert.Empty(book.Authors);
    }    

    [Fact(DisplayName = "When trying to add a subject, should have success.")]
    public void WhenTryingToAddASibject_ShouldHaveSuccess()
    {
        // arrange
        var subject = Subject.Create("Ficção");
        var book = Book.Create("Livro da Vida", "Editora Nova", 1, "2024");

        // act
        book.AddSubject(subject);

        // assert
        Assert.Single(book.Subjects);
    } 

    [Fact(DisplayName = "When trying to change edition of a book, should have success.")]
    public void WhenTryingToChangeEditionOfABook_ShouldHaveSuccess()
    {
        // arrange
        var book = Book.Create("Livro da Vida", "Editora Nova", 1, "2024");

        // act
        book.ChangeEdition(2);

        // assert
        Assert.Equal(2, book.Edition);
    }         
}
