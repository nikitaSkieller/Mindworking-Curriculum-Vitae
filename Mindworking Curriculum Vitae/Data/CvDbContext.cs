using Microsoft.EntityFrameworkCore;
using Mindworking_Curriculum_Vitae.Models;

public class CvDbContext : DbContext
{
    public CvDbContext(DbContextOptions<CvDbContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; } = default!;
    public DbSet<Project> Projects { get; set; } = default!;
    public DbSet<Education> Educations { get; set; } = default!;
    public DbSet<Skill> Skills { get; set; } = default!;
}
