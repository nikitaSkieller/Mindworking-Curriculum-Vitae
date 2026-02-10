using Microsoft.EntityFrameworkCore;
using Mindworking_Curriculum_Vitae.Models;

namespace Mindworking_Curriculum_Vitae.Services.Companies
{
    public interface ICompanyService
    {
        // Active means no end date or end date is in the future (UTC)
        IQueryable<Company> GetActiveCompanies();
        bool IsActive(Company company);
    }

    public class CompanyService : ICompanyService
    {
        private readonly CvDbContext _db;

        public CompanyService(CvDbContext db) => _db = db;

        public IQueryable<Company> GetActiveCompanies()
        {
            var today = DateTime.UtcNow.Date;
            return _db.Companies
                .Where(c => !c.EndDate.HasValue || c.EndDate.Value.Date >= today)
                .OrderByDescending(c => c.StartDate)
                .Include(c => c.Projects);
        }

        public bool IsActive(Company company)
        {
            var today = DateTime.UtcNow.Date;
            return !company.EndDate.HasValue || company.EndDate.Value.Date >= today;
        }
    }
}