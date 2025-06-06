namespace Ouvidoria.Domain.Exceptions;

public class EntityException : Exception
{
    public EntityException(string message) : base(message)
    {
    }

    public static void When(bool hasError, string message)
    {
        if (hasError)
            throw new EntityException(message);
    }
}