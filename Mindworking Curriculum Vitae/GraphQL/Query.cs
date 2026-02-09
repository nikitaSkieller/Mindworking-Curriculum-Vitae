using Microsoft.EntityFrameworkCore;
using Mindworking_Curriculum_Vitae.Models;

public class Query
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Company> GetCompanies([Service] CvDbContext db) =>
        db.Companies.Include(e => e.Projects);

    public Task<Company?> GetCompanyById([ID] int id, [Service] CvDbContext db) =>
        db.Companies.Include(e => e.Projects).FirstOrDefaultAsync(e => e.Id == id);

    // Educations
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Education> GetEducations([Service] CvDbContext db) =>
        db.Educations;

    public Task<Education?> GetEducationById([ID] int id, [Service] CvDbContext db) =>
        db.Educations.FirstOrDefaultAsync(e => e.Id == id);

    // Projects
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Project> GetProjects([Service] CvDbContext db) =>
        db.Projects.Include(p => p.Company);

    public Task<Project?> GetProjectById([ID] int id, [Service] CvDbContext db) =>
        db.Projects.Include(e => e.Company)
            .FirstOrDefaultAsync(e => e.Id == id);

    // Skills
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Skill> GetSkills([Service] CvDbContext db) =>
        db.Skills;

    public Task<Skill?> GetSkillById([ID] int id, [Service] CvDbContext db) =>
        db.Skills.FirstOrDefaultAsync(e => e.Id == id);
}