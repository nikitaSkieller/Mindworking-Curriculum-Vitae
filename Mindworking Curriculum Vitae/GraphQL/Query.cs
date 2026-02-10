using Microsoft.EntityFrameworkCore;
using Mindworking_Curriculum_Vitae.Models;

public class Query
{
    [UsePaging(MaxPageSize = 50, DefaultPageSize = 10)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Company> GetCompanies([Service] CvDbContext db) =>
        db.Companies
          .Include(e => e.Projects)
          .OrderByDescending(e => e.StartDate); 

    public Task<Company?> GetCompanyById([ID] int id, [Service] CvDbContext db) =>
        db.Companies
          .Include(e => e.Projects)
          .FirstOrDefaultAsync(e => e.Id == id);

    // Educations
    [UsePaging(MaxPageSize = 50, DefaultPageSize = 10)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Education> GetEducations([Service] CvDbContext db) =>
        db.Educations;

    public Task<Education?> GetEducationById([ID] int id, [Service] CvDbContext db) =>
        db.Educations.FirstOrDefaultAsync(e => e.Id == id);

    // Projects
    [UsePaging(MaxPageSize = 50, DefaultPageSize = 10)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Project> GetProjects([Service] CvDbContext db) =>
        db.Projects.Include(p => p.Company);

    public Task<Project?> GetProjectById([ID] int id, [Service] CvDbContext db) =>
        db.Projects.Include(e => e.Company)
            .FirstOrDefaultAsync(e => e.Id == id);

    // Skills
    [UsePaging(MaxPageSize = 50, DefaultPageSize = 10)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Skill> GetSkills([Service] CvDbContext db) =>
        db.Skills;

    public Task<Skill?> GetSkillById([ID] int id, [Service] CvDbContext db) =>
        db.Skills.FirstOrDefaultAsync(e => e.Id == id);
}