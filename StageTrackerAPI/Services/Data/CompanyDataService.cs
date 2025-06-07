using Microsoft.EntityFrameworkCore;
using StageTracker.API.Data;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.API.Services.Data
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
