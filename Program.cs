using Microsoft.EntityFrameworkCore;
using Mindworking_Curriculum_Vitae.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<CvDbContext>(opt =>
    opt.UseSqlite("Data Source=cv.db"));


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<CvDbContext>>();
    using var db = dbFactory.CreateDbContext();
    db.Database.EnsureCreated();
    SeedData.EnsureSeeded(db);
}

app.MapGet("/", () => Results.Redirect("/graphql"));

app.MapGraphQL();

app.Run();
