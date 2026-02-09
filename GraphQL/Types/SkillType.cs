using Mindworking_Curriculum_Vitae.Models;

namespace Mindworking_Curriculum_Vitae.GraphQL.Types
{
    public class SkillType : ObjectType<Skill>
    {
        protected override void Configure(IObjectTypeDescriptor<Skill> descriptor)
        {
            descriptor.Field(f => f.Id).ID();
            descriptor.Field(f => f.Name).Type<StringType>();
            descriptor.Field(f => f.Description).Type<StringType>();
            descriptor.Field(f => f.Level).Type<StringType>();
        }
    }
}
