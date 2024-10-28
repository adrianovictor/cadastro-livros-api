using System;
using BookStoreManagerService.Domain.Model;

namespace BookStoreManagerService.UnitTests.Domain.Model;

public class AuthorTest
{
    [Fact(DisplayName = "Constructor, when trying to create an author, should have a default values.")]
    public void Constructor_WhenTryingToCreateAnAuthor_ShouldHaveDefaultValues()
    {
        // arrange
        var author = Author.Create("Willian Shakespear");

        // assert
        Assert.Equal("Willian Shakespear", author.Name);  
    }   

    [Fact(DisplayName = "When trying to change name of an author, should have success.")]
    public void WhenTryingToChangeNameOfAnAuthor_ShouldHaveSuccess()
    {
        // arrange
        var author = Author.Create("Willian Shakespear");

        // act
        author.ChangeName("Martin Luther King");

        // assert
        Assert.Equal("Martin Luther King", author.Name);
    }  
}
