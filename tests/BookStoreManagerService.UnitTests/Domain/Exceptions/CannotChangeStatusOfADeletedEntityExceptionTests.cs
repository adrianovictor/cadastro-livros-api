using System;
using BookStoreManagerService.Domain.Enum;
using BookStoreManagerService.Domain.Exceptions;
using BookStoreManagerService.Domain.Model;

namespace BookStoreManagerService.UnitTests.Domain.Exceptions;

public class CannotChangeStatusOfADeletedEntityExceptionTests
{
    [Fact(DisplayName = "When trying to change status of a deleted entity, should return an exception.")]
    public void WhenTryingToChangeStatusOfADeletedEntity_ShouldReturnAnException()
    {
        // arrange
        var book = Book.Create("Livro da Vida", "Editora Nova", 1, "2024");
        var errorMessage = "Não é possível alterar o status de um objeto deletado.";

        book.ChangeStatus(Status.Deleted);

        // act
        var error = Assert.Throws<CannotChangeStatusOfADeletedEntityException>(() => book.ChangeStatus(Status.Active));

        // assert
        Assert.Equal(errorMessage, error.Message);
    }
}
