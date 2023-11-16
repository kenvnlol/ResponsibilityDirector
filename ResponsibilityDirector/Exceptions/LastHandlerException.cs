namespace ResponsibilityDirector.Exceptions;

internal class LastHandlerException : Exception
{
    public LastHandlerException()
    {
    }

    public LastHandlerException(string message)
        : base(message)
    {
    }

    public LastHandlerException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
