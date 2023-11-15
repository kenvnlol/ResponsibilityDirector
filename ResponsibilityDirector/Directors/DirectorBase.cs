using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using ResponsibilityDirector.ResponsibilityHandlers;
using System;

namespace ResponsibilityDirector.Directors;

public abstract class DirectorBase<TRequest, TResponse> : IDirector<TRequest, TResponse>
{
    public IResponsibilityHandler<TRequest, TResponse> Initiator { get; private set; }

    public List<IResponsibilityHandler<TRequest, TResponse>> _handlers { get; init; }
    protected DirectorBase([FromKeyedServices("")] IEnumerable<IResponsibilityHandler<TRequest, TResponse>> handlers)
    {
        Guard.IsNotNull(handlers, nameof(handlers));

        if (!handlers.Any()) throw new ArgumentException("Handler list cannot be empty", nameof(handlers));

        _handlers = handlers.ToList();
        Initiator = handlers.First();
        SetSequence();
    }

    protected void SetSequence()
    {
        for (int i = 0; i < _handlers.Count - 1; i++)
        {
            _handlers[i].SetNext(_handlers[i + 1]);
        }
    }

    public abstract Task<TResponse> Handle(TRequest request);

}
