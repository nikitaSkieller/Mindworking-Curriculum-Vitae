using Mindworking_Curriculum_Vitae.Models;

namespace Mindworking_Curriculum_Vitae.GraphQL.Types
{
    public class EducationType : ObjectType<Education>
    {
        protected override void Configure(IObjectTypeDescriptor<Education> descriptor)
        {
            descriptor.Field(f => f.Id).ID();
            descriptor.Field(f => f.School).Type<StringType>();
            descriptor.Field(f => f.Degree).Type<StringType>();
            descriptor.Field(f => f.StartDate).Type<DateType>();
            descriptor.Field(f => f.EndDate).Type<DateType>();
        }
    }
}
