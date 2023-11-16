using Microsoft.Extensions.DependencyInjection;
using ResponsibilityDirector.Options;


namespace ResponsibilityDirector.Registrar;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddResponsibilityDirector(this IServiceCollection service, Action<ResponsibilityDirectorOptions> options)
    {
        var configure = new ResponsibilityDirectorOptions(service);
        options(configure);

        return service;
    }
}
