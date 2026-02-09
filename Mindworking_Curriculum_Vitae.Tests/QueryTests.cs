using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Mindworking_Curriculum_Vitae.Data;
using Mindworking_Curriculum_Vitae.GraphQL.Types;
using HotChocolate;

namespace Mindworking_Curriculum_Vitae.Tests
{
    public class QueryTests
    {
        [Fact]
        public async Task Companies_query_returns_seeded_data()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CvDbContext>(o =>
                o.UseInMemoryDatabase(databaseName: $"cv-tests-{Guid.NewGuid()}"));

            var builder = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
                db.Database.EnsureCreated();
                SeedData.EnsureSeeded(db);
            }

            var executor = await builder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              companies(order: { name: ASC }) {
                nodes {
                  name
                  title
                  projects(order: { name: ASC }) {
                    nodes { name }
                  }
                }
              }
            }");

            result.ToJson().MatchSnapshot();
        }

        [Fact]
        public async Task CompanyById_query_returns_expected_company()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CvDbContext>(o =>
                o.UseInMemoryDatabase(databaseName: $"cv-tests-{Guid.NewGuid()}"));

            var builder = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
                db.Database.EnsureCreated();
                SeedData.EnsureSeeded(db);
            }

            var executor = await builder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              companyById(id: 1) {
                name
                title
              }
            }");

            result.ToJson().MatchSnapshot();
        }

        [Fact]
        public async Task Educations_query_returns_seeded_data()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CvDbContext>(o =>
                o.UseInMemoryDatabase(databaseName: $"cv-tests-{Guid.NewGuid()}"));

            var builder = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
                db.Database.EnsureCreated();
                SeedData.EnsureSeeded(db);
            }

            var executor = await builder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              educations(order: { institution: ASC }) {
                nodes {
                  institution
                  title
                  startDate
                  endDate
                }
              }
            }");

            result.ToJson().MatchSnapshot();
        }

        [Fact]
        public async Task EducationById_query_returns_expected_education()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CvDbContext>(o =>
                o.UseInMemoryDatabase(databaseName: $"cv-tests-{Guid.NewGuid()}"));

            var builder = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
                db.Database.EnsureCreated();
                SeedData.EnsureSeeded(db);
            }

            var executor = await builder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              educationById(id: 1) {
                institution
                title
                startDate
                endDate
              }
            }");

            result.ToJson().MatchSnapshot();
        }

        [Fact]
        public async Task Projects_query_returns_seeded_data_with_company()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CvDbContext>(o =>
                o.UseInMemoryDatabase(databaseName: $"cv-tests-{Guid.NewGuid()}"));

            var builder = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
                db.Database.EnsureCreated();
                SeedData.EnsureSeeded(db);
            }

            var executor = await builder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              projects(order: { name: ASC }) {
                nodes {
                  name
                  description
                  company {
                    name
                    title
                  }
                }
              }
            }");

            result.ToJson().MatchSnapshot();
        }

        [Fact]
        public async Task ProjectById_query_returns_expected_project_with_company()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CvDbContext>(o =>
                o.UseInMemoryDatabase(databaseName: $"cv-tests-{Guid.NewGuid()}"));

            var builder = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
                db.Database.EnsureCreated();
                SeedData.EnsureSeeded(db);
            }

            var executor = await builder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              projectById(id: 1) {
                name
                description
                company {
                  name
                  title
                }
              }
            }");

            result.ToJson().MatchSnapshot();
        }

        [Fact]
        public async Task Skills_query_returns_seeded_data()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CvDbContext>(o =>
                o.UseInMemoryDatabase(databaseName: $"cv-tests-{Guid.NewGuid()}"));

            var builder = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
                db.Database.EnsureCreated();
                SeedData.EnsureSeeded(db);
            }

            var executor = await builder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              skills(order: { name: ASC }) {
                nodes {
                  name
                  level
                }
              }
            }");

            result.ToJson().MatchSnapshot();
        }

        [Fact]
        public async Task SkillById_query_returns_expected_skill()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CvDbContext>(o =>
                o.UseInMemoryDatabase(databaseName: $"cv-tests-{Guid.NewGuid()}"));

            var builder = services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            using (var provider = services.BuildServiceProvider())
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CvDbContext>();
                db.Database.EnsureCreated();
                SeedData.EnsureSeeded(db);
            }

            var executor = await builder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"
            {
              skillById(id: 1) {
                name
                level
              }
            }");

            result.ToJson().MatchSnapshot();
        }
    }
}
