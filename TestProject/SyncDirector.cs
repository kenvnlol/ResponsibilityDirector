﻿using ResponsibilityDirector.Directors;
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


public record AuthorizationLevel(string Level);

public record AuthorizationMessage(string Message);


public class SyncHandlerOne : ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>
{
    public async override Task<AuthorizationMessage> Handle(AuthorizationLevel request)
    {
        if (request.Level == "Member")
        {
            var response = _nextHandler?.Handle(request) ?? throw new InvalidOperationException("There should be a next handler.");
            return await response;
        }

        return new AuthorizationMessage("You failed the authorization.");
    }
}

public class SyncHandlerTwo : ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>
{
    public async override Task<AuthorizationMessage> Handle(AuthorizationLevel request)
    {
        if (request.Level == "Admin")
        {
            var response = _nextHandler?.Handle(request) ?? throw new InvalidOperationException("There should be a next handler.");
            return await response;
        }

        return new AuthorizationMessage("You failed the authorization.");
    }
}

public class SyncHandlerThree : ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>
{
    public override Task<AuthorizationMessage> Handle(AuthorizationLevel request)
    {
        if (request.Level == "SuperAdmin")
        {
            return Task.FromResult(new AuthorizationMessage("Success!"));
        }

        return Task.FromResult(new AuthorizationMessage("You failed the authorization."));
    }
}