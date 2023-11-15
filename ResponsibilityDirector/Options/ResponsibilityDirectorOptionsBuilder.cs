using Microsoft.Extensions.DependencyInjection;
using ResponsibilityDirector.Directors;
using ResponsibilityDirector.ResponsibilityHandlers;

namespace ResponsibilityDirector.Options;
public class ResponsibilityDirectorOptionsBuilder<TDirector, TRequest, TResponse>
    where TRequest : class
    where TResponse : class
    where TDirector : Director<TRequest, TResponse>
{
    private readonly IServiceCollection _services;

    internal ResponsibilityDirectorOptionsBuilder(IServiceCollection services)
    {
        _services = services;
    }

    public ResponsibilityDirectorOptionsBuilder<TDirector, TRequest, TResponse> AddHandler<TBaseHandler, TDerivedHandler>() 
        where TBaseHandler : ResponsibilityHandler<TRequest, TResponse>
        where TDerivedHandler : TBaseHandler
    {
        _services.AddScoped<TBaseHandler, TDerivedHandler>();
        return this;
    }
}