using Mindworking_Curriculum_Vitae.Models;

namespace Mindworking_Curriculum_Vitae.GraphQL
{
    public class Mutation
    {
        public async Task<Skill> AddSkillAsync(string name, string level, [Service] CvDbContext db, CancellationToken ct)
        {
            var skill = new Skill { Name = name, Level = level };
            db.Skills.Add(skill);
            await db.SaveChangesAsync(ct);
            return skill;
        }
    }
}