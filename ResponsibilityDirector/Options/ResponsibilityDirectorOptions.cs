using Microsoft.Extensions.DependencyInjection;
using ResponsibilityDirector.Directors;


namespace ResponsibilityDirector.Options;

public static class ResponsibilityDirectorOptions
{
    public static ResponsibilityDirectorOptionsBuilder<TDirector, TRequest, TResponse>
        ConfigureDirector<TDirector, TRequest, TResponse>(this IServiceCollection services)
        where TRequest : class
        where TResponse : class
        where TDirector : Director<TRequest, TResponse>
    {
        services.AddScoped<TDirector>();
        return new ResponsibilityDirectorOptionsBuilder<TDirector, TRequest, TResponse>(
            services);
    }
}