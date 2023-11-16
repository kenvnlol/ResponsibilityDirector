using ResponsibilityDirector.Exceptions;

namespace ResponsibilityDirector.ResponsibilityHandlers;

public abstract class ResponsibilityHandler<TRequest, TResponse> 
    where TRequest : class
    where TResponse : class
{
    protected ResponsibilityHandler<TRequest, TResponse>? _nextHandler;

    internal ResponsibilityHandler<TRequest, TResponse> SetNext(ResponsibilityHandler<TRequest, TResponse> handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public abstract Task<TResponse> Handle(TRequest request);

    /// <summary>
    /// Progresses to the next handler in the chain if a handler can be found.
    /// </summary>
    /// <param name="request">The request to be handled by the next handler.</param>
    /// <returns>A Task representing the asynchronous operation of the next handler.</returns>
    /// <exception cref="LastHandlerException">
    /// </exception>
    public Task<TResponse> MoveNext(TRequest request)
        => _nextHandler is null 
        ? throw new LastHandlerException("Cannot move next from the last handler.") 
        : _nextHandler.Handle(request);
}



public abstract class ResponsibilityHandler<TRequest>
    where TRequest : class
{
    protected ResponsibilityHandler<TRequest>? _nextHandler;

    internal ResponsibilityHandler<TRequest> SetNext(ResponsibilityHandler<TRequest> handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public abstract Task Handle(TRequest request);
}