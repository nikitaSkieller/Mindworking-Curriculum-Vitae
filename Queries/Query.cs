using Microsoft.EntityFrameworkCore;
using Mindworking_Curriculum_Vitae.Data;
using Mindworking_Curriculum_Vitae.Models;

public class Query
{
    public IQueryable<Company> GetCompanies([Service] CvDbContext db) =>
        db.Companies.Include(e => e.Projects);

    public Task<Company?> GetCompanyById(int id, [Service] CvDbContext db) =>
        db.Companies.Include(e => e.Projects).FirstOrDefaultAsync(e => e.Id == id);

    public IQueryable<Education> GetEducations([Service] CvDbContext db) => db.Educations;
    public Task<Company?> GetEducationById(int id, [Service] CvDbContext db) =>
    db.Companies.Include(e => e.Projects).FirstOrDefaultAsync(e => e.Id == id);

    public IQueryable<Project> GetProjects([Service] CvDbContext db) => db.Projects;
    public Task<Company?> GetProjectById(int id, [Service] CvDbContext db) =>
    db.Companies.Include(e => e.Projects).FirstOrDefaultAsync(e => e.Id == id);

    public IQueryable<Skill> GetSkills([Service] CvDbContext db) => db.Skills;
    public Task<Company?> GetSkillById(int id, [Service] CvDbContext db) =>
    db.Companies.Include(e => e.Projects).FirstOrDefaultAsync(e => e.Id == id);
}