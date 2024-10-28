using System;
using BookStoreManagerService.Domain.Model;

namespace BookStoreManagerService.UnitTests.Domain.Model;

public class SubjectTest
{
    [Fact(DisplayName = "Constructor, when trying to create a subject, should have a default values.")]
    public void Constructor_WhenTryingToCreateASubject_ShouldHaveDefaultValues()
    {
        // arrange
        var subject = Subject.Create("Ficção");

        // assert
        Assert.Equal("Ficção", subject.Description);        
    }   

    [Fact(DisplayName = "When trying to change description of a subject, should have success.")]
    public void WhenTryingToChangeDescriptionOfASubject_ShouldHaveSuccess()
    {
        // arrange
        var subject = Subject.Create("Ficção");

        // act
        subject.ChangeDescription("Aventura");

        // assert
        Assert.Equal("Aventura", subject.Description);
    }  
}
