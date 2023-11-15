//using Microsoft.Extensions.DependencyInjection;
//using ResponsibilityDirector.Options;

//namespace ResponsibilityDirector.Registrar;

//public static class IServiceCollectionExtensions
//{
//    public static IServiceCollection AddResponsibilityDirector(this IServiceCollection service,
//        Action<ResponsibilityDirectorOptions> configure)
//    {
//        var config = new ResponsibilityDirectorOptions();
//        configure(config);

//        foreach (var director in config.DirectorSettings)
//        {
//            foreach (var handler in director.HandlerTypes)
//            {
//                service.AddKeyedScoped(director.InterfaceType, director.Key, handler);
//            }

//            service.AddScoped(director.DirectorType);
//        }

//        return service;
//    }
//}
