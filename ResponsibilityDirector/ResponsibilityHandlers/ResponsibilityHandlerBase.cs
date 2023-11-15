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