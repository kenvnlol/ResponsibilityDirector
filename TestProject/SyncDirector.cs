using ResponsibilityDirector.Directors;
using ResponsibilityDirector.ResponsibilityHandlers;

namespace TestProject;

public class SyncDirector : Director<AuthorizationLevel, AuthorizationMessage>
{
    public SyncDirector(IEnumerable<ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>> handlers) : base(handlers)
    {
    }

    public override Task<AuthorizationMessage> Initiate(AuthorizationLevel request)
    {
        var result = _initiator.Handle(request);

        return result;
    }
}


public record AuthorizationLevel(int Level);

public record AuthorizationMessage(string Message);


public class SyncHandlerOne : ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>
{
    public async override Task<AuthorizationMessage> Handle(AuthorizationLevel request)
    {
        if (request.Level < 1)
        {
            return new AuthorizationMessage("You failed the authorization.");
        }

        var response = _nextHandler?.Handle(request) ?? throw new InvalidOperationException("There should be a next handler.");
        return await response;
    }
}

public class SyncHandlerTwo : ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>
{
    public async override Task<AuthorizationMessage> Handle(AuthorizationLevel request)
    {
        if (request.Level < 2)
        {
            return new AuthorizationMessage("You failed the authorization.");
        }

        var response = _nextHandler?.Handle(request) ?? throw new InvalidOperationException("There should be a next handler.");
        return await response;
    }
}

public class SyncHandlerThree : ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>
{
    public override Task<AuthorizationMessage> Handle(AuthorizationLevel request)
    {
        if (request.Level < 3)
        {
            return Task.FromResult(new AuthorizationMessage("You failed the authorization."));
        }

        return Task.FromResult(new AuthorizationMessage("Success!"));
    }
}