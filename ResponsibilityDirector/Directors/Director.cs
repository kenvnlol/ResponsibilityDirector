using ResponsibilityDirector.ResponsibilityHandlers;

namespace ResponsibilityDirector.Directors;

public abstract class Director<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    public readonly ResponsibilityHandler<TRequest, TResponse> _initiator;

    protected Director(IEnumerable<ResponsibilityHandler<TRequest, TResponse>> handlers)
    {
        // Guard.IsNotNull(handlers, nameof(handlers));

        if (!handlers.Any()) throw new ArgumentException("Handler list cannot be empty", nameof(handlers));

        _initiator = handlers.First();

        handlers.Zip(handlers.Skip(1), (current, next) => {
            current.SetNext(next);
            return current;
        }).ToList();
    }

    public abstract Task<TResponse> Initiate(TRequest request);
}


//public abstract class Director<TRequest>
//    where TRequest : class
//{
//    private readonly ResponsibilityHandler<TRequest> _initiator;

//    protected Director(IEnumerable<ResponsibilityHandler<TRequest>> handlers)
//    {
//        // Guard.IsNotNull(handlers, nameof(handlers));

//        if (!handlers.Any()) throw new ArgumentException("Handler list cannot be empty", nameof(handlers));

//        _initiator = handlers.First();

//        handlers.Zip(handlers.Skip(1), (current, next) => {
//            current.SetNext(next);
//            return current;
//        }).ToList();
//    }

//    public abstract Task Initiate(TRequest request);
//}

