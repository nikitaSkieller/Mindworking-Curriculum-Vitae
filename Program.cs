var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/graphql"));

app.MapGraphQL();

app.Run();
