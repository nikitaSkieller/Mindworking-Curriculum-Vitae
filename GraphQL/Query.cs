using Microsoft.EntityFrameworkCore;
using Mindworking_Curriculum_Vitae.Data;
using Mindworking_Curriculum_Vitae.Models;
using HotChocolate.Data;

public class Query
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Company> GetCompanies([Service] CvDbContext db) =>
        db.Companies.Include(e => e.Projects);

    public Task<Company?> GetCompanyById(int id, [Service] CvDbContext db) =>
        db.Companies.Include(e => e.Projects).FirstOrDefaultAsync(e => e.Id == id);

    // Educations
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Education> GetEducations([Service] CvDbContext db) =>
        db.Educations;

    public Task<Education?> GetEducationById(int id, [Service] CvDbContext db) =>
        db.Educations.FirstOrDefaultAsync(e => e.Id == id);

    // Projects
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Project> GetProjects([Service] CvDbContext db) =>
        db.Projects;

    public Task<Project?> GetProjectById(int id, [Service] CvDbContext db) =>
        db.Projects.FirstOrDefaultAsync(e => e.Id == id);

    // Skills
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Skill> GetSkills([Service] CvDbContext db) =>
        db.Skills;

    public Task<Skill?> GetSkillById(int id, [Service] CvDbContext db) =>
        db.Skills.FirstOrDefaultAsync(e => e.Id == id);
}