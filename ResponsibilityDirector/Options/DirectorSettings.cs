namespace ResponsibilityDirector.Options;

internal class DirectorSettings
{
    internal DirectorSettings(Type directorType, string key, Type interfaceType, params Type[] handlers)
    {
        DirectorType = directorType;
        Key = key;
        InterfaceType = interfaceType;
        HandlerTypes.AddRange(handlers);
    }

    internal Type DirectorType { get; init; }
    internal List<Type> HandlerTypes { get; } = new List<Type>();
    internal string Key { get; init; }
    internal Type InterfaceType { get; init; }
}
