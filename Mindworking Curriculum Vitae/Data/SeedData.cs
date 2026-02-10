using Mindworking_Curriculum_Vitae.Models;

namespace Mindworking_Curriculum_Vitae.Data
{
    public class SeedData
    {
        public static void EnsureSeeded(CvDbContext db)
        {
            // Seed only when database is empty for any of the sets to avoid partial seeding preventing others.
            var needCompanies = !db.Companies.Any();
            var needProjects = !db.Projects.Any();
            var needSkills = !db.Skills.Any();
            var needEducations = !db.Educations.Any();

            if (!needCompanies && !needProjects && !needSkills && !needEducations) return;

            // Companies and Projects (ensure > 10 each)
            if (needCompanies || needProjects)
            {
                var companies = new List<Company>();
                var projects = new List<Project>();

                // Create 12 companies, each with 2 projects
                for (int i = 1; i <= 12; i++)
                {
                    var company = new Company
                    {
                        Name = $"Example Consulting {i}",
                        Title = (i % 3) switch
                        {
                            0 => "Software Engineer",
                            1 => "Senior Software Engineer",
                            _ => "Lead Engineer"
                        },
                        StartDate = new DateTime(2015 + (i % 8), (i % 12) + 1, 1),
                        EndDate = i % 4 == 0 ? new DateTime(2018 + (i % 6), ((i + 3) % 12) + 1, 1) : null,
                        Summary = $"Built backend services, GraphQL APIs, and microservices (batch {i}).",
                        Projects = new List<Project>()
                    };

                    // Two projects per company
                    var p1 = new Project
                    {
                        Name = $"CV Service {i}",
                        Summary = "GraphQL backend for CV data.",
                        Company = company
                    };
                    var p2 = new Project
                    {
                        Name = $"Reporting Service {i}",
                        Summary = "Background processing and reporting pipeline.",
                        Company = company
                    };

                    company.Projects.Add(p1);
                    company.Projects.Add(p2);

                    companies.Add(company);
                    projects.Add(p1);
                    projects.Add(p2);
                }

                // Add a couple of standalone projects (still attached to first company for consistency)
                var firstCompany = companies.First();
                var extraProjects = new[]
                {
                    new Project { Name = "Auth Gateway", Summary = "Unified authentication gateway.", Company = firstCompany },
                    new Project { Name = "Metrics Collector", Summary = "Telemetry ingestion and dashboards.", Company = firstCompany }
                };
                projects.AddRange(extraProjects);
                firstCompany.Projects.AddRange(extraProjects);

                if (needCompanies) db.Companies.AddRange(companies);
                if (needProjects) db.Projects.AddRange(projects);
            }

            // Skills (ensure > 10)
            if (needSkills)
            {
                db.Skills.AddRange(new[]
                {
                    new Skill { Name = "C#", Level = "Advanced", Description = "C# development" },
                    new Skill { Name = "GraphQL", Level = "Intermediate", Description = "GraphQL APIs" },
                    new Skill { Name = ".NET", Level = "Advanced", Description = "Modern .NET development" },
                    new Skill { Name = "EF Core", Level = "Advanced", Description = "Entity Framework Core" },
                    new Skill { Name = "SQL", Level = "Advanced", Description = "Database design and optimization" },
                    new Skill { Name = "Azure", Level = "Intermediate", Description = "Azure services and deployments" },
                    new Skill { Name = "Docker", Level = "Intermediate", Description = "Containerization and images" },
                    new Skill { Name = "Kubernetes", Level = "Intermediate", Description = "Orchestration" },
                    new Skill { Name = "REST", Level = "Advanced", Description = "REST API design" },
                    new Skill { Name = "Microservices", Level = "Intermediate", Description = "Distributed systems design" },
                    new Skill { Name = "CI/CD", Level = "Intermediate", Description = "Automation pipelines" },
                    new Skill { Name = "xUnit", Level = "Intermediate", Description = "Automated testing" }
                });
            }

            // Educations (ensure > 10)
            if (needEducations)
            {
                var educations = new List<Education>();
                var schools = new[]
                {
                    "Example University", "Tech Institute", "Global IT Academy", "City College of Computing",
                    "International School of Software", "Metropolitan Tech", "Northern Polytech",
                    "Southern Engineering School", "Western Tech University", "Eastern Computing College",
                    "Central University of Technology", "National School of Engineering"
                };

                for (int i = 0; i < schools.Length; i++)
                {
                    educations.Add(new Education
                    {
                        School = schools[i],
                        Degree = (i % 3) switch
                        {
                            0 => "BSc Software Engineering",
                            1 => "MSc Computer Science",
                            _ => "BEng Information Technology"
                        },
                        StartDate = new DateTime(2010 + i, ((i % 12) + 1), 1),
                        EndDate = new DateTime(2013 + i, (((i + 6) % 12) + 1), 1)
                    });
                }

                db.Educations.AddRange(educations);
            }

            db.SaveChanges();
        }
    }
}
