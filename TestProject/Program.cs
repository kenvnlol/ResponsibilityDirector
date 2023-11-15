using ResponsibilityDirector.Options;
using ResponsibilityDirector.ResponsibilityHandlers;
using TestProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDirector<SyncDirector, AuthorizationLevel, AuthorizationMessage>()
    .AddHandler<ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>, SyncHandlerOne>()
    .AddHandler<ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>, SyncHandlerTwo>()
    .AddHandler<ResponsibilityHandler<AuthorizationLevel, AuthorizationMessage>, SyncHandlerThree>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
