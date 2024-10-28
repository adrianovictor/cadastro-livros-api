namespace BookStoreManagerService.Domain.Exceptions;

public class CannotChangeStatusOfADeletedEntityException: Exception
{
    public CannotChangeStatusOfADeletedEntityException(): base("Não é possível alterar o status de um objeto deletado.") {}
}
