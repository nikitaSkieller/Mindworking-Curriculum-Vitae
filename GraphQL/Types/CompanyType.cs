using Mindworking_Curriculum_Vitae.Models;
using Microsoft.EntityFrameworkCore;

namespace Mindworking_Curriculum_Vitae.GraphQL.Types
{
    public class CompanyType : ObjectType<Company>
    {
        protected override void Configure(IObjectTypeDescriptor<Company> descriptor)
        {
            descriptor.Field(f => f.Id).ID();
            descriptor.Field(f => f.Name).Type<StringType>();
            descriptor.Field(f => f.Summary).Type<StringType>();
            descriptor.Field(f => f.Title).Type<StringType>();
            descriptor.Field(f => f.StartDate).Type<DateTimeType>();
            descriptor.Field(f => f.EndDate).Type<DateTimeType>();

            descriptor
                .Field(f => f.Projects)
                .Type<ListType<NonNullType<ProjectType>>>()
                .ResolveWith<Resolvers>(r => r.GetProjects(default!, default!))
                .UsePaging()
                .UseFiltering()
                .UseSorting();
        }

        private sealed class Resolvers
        {
            public IQueryable<Project> GetProjects([Parent] Company company, [Service] CvDbContext db) =>
                db.Projects
                  .Where(p => p.CompanyId == company.Id)
                  .Include(p => p.Company);
        }
    }
}
