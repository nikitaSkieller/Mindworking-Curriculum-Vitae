using Mindworking_Curriculum_Vitae.Models;
using Microsoft.EntityFrameworkCore;

namespace Mindworking_Curriculum_Vitae.Data
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options) { }

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Education> Educations => Set<Education>();
        public DbSet<Skill> Skills => Set<Skill>();
    }
}
