using Mindworking_Curriculum_Vitae.Models;

namespace Mindworking_Curriculum_Vitae.GraphQL.Types
{
    public class ProjectType : ObjectType<Project>
    {
        protected override void Configure(IObjectTypeDescriptor<Project> descriptor)
        {
            descriptor.Field(f => f.Id).ID();
            descriptor.Field(f => f.Name).Type<StringType>();
            descriptor.Field(f => f.Summary).Type<StringType>();
            descriptor.Field(f => f.CompanyId).ID();

            descriptor
                .Field(f => f.Company)
                .Type<CompanyType>()
                .ResolveWith<ProjectResolvers>(r => r.GetCompany(default!, default!));
        }

        private sealed class ProjectResolvers
        {
            public Company? GetCompany([Parent] Project project, [Service] CvDbContext db) =>
                db.Companies.FirstOrDefault(c => c.Id == project.CompanyId);
        }
    }
}
