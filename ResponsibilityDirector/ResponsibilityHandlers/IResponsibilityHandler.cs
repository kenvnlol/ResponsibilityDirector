namespace ResponsibilityDirector.ResponsibilityHandlers;

public interface IResponsibilityHandler<TRequest, TResponse>
{
    IResponsibilityHandler<TRequest, TResponse> SetNext(IResponsibilityHandler<TRequest, TResponse> handler);
    TResponse? Handle(TRequest request);
}

