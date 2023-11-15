namespace ResponsibilityDirector.ResponsibilityHandlers;

public abstract class ResponsibilityHandlerBase<TRequest, TResponse> : IResponsibilityHandler<TRequest, TResponse>
{
    public IResponsibilityHandler<TRequest, TResponse>? _nextHandler;

    public IResponsibilityHandler<TRequest, TResponse> SetNext(IResponsibilityHandler<TRequest, TResponse> handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public abstract TResponse? Handle(TRequest request);
}
