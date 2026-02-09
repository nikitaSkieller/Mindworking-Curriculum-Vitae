using Mindworking_Curriculum_Vitae.Models;

namespace Mindworking_Curriculum_Vitae.Data
{
    public class SeedData
    {
        public static void EnsureSeeded(CvDbContext db)
        {
            if (db.Companies.Any()) return;

            var exp = new Company
            {
                Name = "Example Consulting",
                Title = "Software Engineer",
                StartDate = new DateTime(2023, 1, 1),
                Summary = "Built backend services and GraphQL APIs."
            };

            exp.Projects.Add(new Project
            {
                Name = "CV Service",
                Summary = "GraphQL backend for CV data.",
            });

            db.Companies.Add(exp);

            db.Skills.AddRange(
                new Skill { Name = "C#", Level = "Advanced" },
                new Skill { Name = "GraphQL", Level = "Intermediate" }
            );

            db.Educations.Add(new Education
            {
                School = "Example University",
                Degree = "BSc Software Engineering",
                StartDate = new DateTime(2020, 8, 1),
                EndDate = new DateTime(2023, 6, 1)
            });

            db.SaveChanges();
        }
    }
}
