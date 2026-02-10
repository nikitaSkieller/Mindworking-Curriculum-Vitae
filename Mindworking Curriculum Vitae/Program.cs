using Microsoft.EntityFrameworkCore;
using Mindworking_Curriculum_Vitae.Data;
using Mindworking_Curriculum_Vitae.GraphQL;
using Mindworking_Curriculum_Vitae.GraphQL.Types;
using Mindworking_Curriculum_Vitae.Services.Companies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CvDbContext>(opt =>
    opt.UseSqlite("Data Source=cv.db"));

builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<SkillType>()
    .AddType<CompanyType>()
    .AddType<ProjectType>()
    .AddType<EducationType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
    db.Database.EnsureCreated();
    SeedData.EnsureSeeded(db);
}

app.MapGet("/", () => Results.Redirect("/graphql"));
app.MapGraphQL();
app.Run();
