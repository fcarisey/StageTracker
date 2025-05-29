using Microsoft.EntityFrameworkCore;
using StageTracker.Data;
using StageTracker.Models;

namespace StageTracker.Services.Data
{
    public class CompanyDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _context.Companies
                                 .Include(c => c.Internships)
                                    .ThenInclude(i => i.Student)
                                        .ThenInclude(s => s.Classe)
                                 .ToListAsync();
        }

        public async void AddCompanyAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async void UpdateCompanyAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async void DeleteCompanyAsync(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}
