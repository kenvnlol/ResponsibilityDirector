using Microsoft.Extensions.DependencyInjection;
using ResponsibilityDirector.Directors;


namespace ResponsibilityDirector.Options;

public class ResponsibilityDirectorOptions
{
    private readonly IServiceCollection _services;
    public ResponsibilityDirectorOptions(IServiceCollection services)
    {
        _services = services;
    }
    public ResponsibilityDirectorOptionsBuilder<TDirector, TRequest, TResponse>
        ConfigureDirector<TDirector, TRequest, TResponse>()
        where TRequest : class
        where TResponse : class
        where TDirector : Director<TRequest, TResponse>
    {
        _services.AddScoped<TDirector>();
        return new ResponsibilityDirectorOptionsBuilder<TDirector, TRequest, TResponse>(
            _services);
    }
}