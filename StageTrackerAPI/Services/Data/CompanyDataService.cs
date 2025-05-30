using Microsoft.EntityFrameworkCore;
using StageTrackerAPI.Data;
using StageTrackerAPI.Models;

namespace StageTrackerAPI.Services.Data
{
    public class CompanyDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<CompanyDto>> GetAllCompaniesAsync()
        {
            return await _context.Companies
                                 .Include(c => c.Internships)
                                    .ThenInclude(i => i.Student)
                                        .ThenInclude(s => s.Classe)
                                 .ToListAsync();
        }

        public async void AddCompanyAsync(CompanyDto company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async void UpdateCompanyAsync(CompanyDto company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async void DeleteCompanyAsync(CompanyDto company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}
