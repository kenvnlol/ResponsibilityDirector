using ResponsibilityDirector.Directors;
using ResponsibilityDirector.ResponsibilityHandlers;

namespace ResponsibilityDirector.Options;

public class ResponsibilityDirectorOptions
{
    internal List<DirectorSettings> DirectorSettings { get; } = new List<DirectorSettings>();

    public void ConfigureDirector<TDirector, TRequest, TResponse>(string key, params Type[] handlers)
        where TDirector : class, IDirector<TRequest, TResponse>
    {
        var interfaceType = typeof(IResponsibilityHandler<TRequest, TResponse>);

        foreach (var type in handlers)
        {
            if (interfaceType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            {
                continue;
            }
            else
            {
                throw new ArgumentException($"Type {type.Name} does not implement {interfaceType.Name}");
            }
        }

        DirectorSettings.Add(new DirectorSettings(typeof(TDirector), key, interfaceType, handlers));
    }
}
