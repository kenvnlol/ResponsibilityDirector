using ResponsibilityDirector.ResponsibilityHandlers;

namespace ResponsibilityDirector.Directors;

public interface IDirector<TRequest, TResponse>
{
    List<IResponsibilityHandler<TRequest, TResponse>> _handlers { get; init; }
    public abstract Task<TResponse> Initiate(TRequest request);
}
