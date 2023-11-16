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

    public ResponsibilityDirectorOptionsBuilder<TDirector, TRequest, TResponse> AddHandler<THandler>() 
        where THandler : ResponsibilityHandler<TRequest, TResponse>
    {
        _services.AddScoped<ResponsibilityHandler<TRequest, TResponse>, THandler>();
        return this;
    }
}