using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Mindworking_Curriculum_Vitae.GraphQL.Types;
using HotChocolate;

namespace Mindworking_Curriculum_Vitae.Tests
{
    public class SchemaChangeTests
    {
        [Fact]
        public async Task Schema_matches_application_setup()
        {
            var builder = new ServiceCollection()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<SkillType>()
                .AddType<CompanyType>()
                .AddType<ProjectType>()
                .AddType<EducationType>()
                .AddFiltering()
                .AddSorting();

            var schema = await builder.BuildSchemaAsync();
            schema.ToString().MatchSnapshot();
        }
    }
}