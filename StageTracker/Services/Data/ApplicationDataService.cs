using Microsoft.EntityFrameworkCore;
using StageTracker.WPF.Data;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.WPF.Services.Data;

public class ApplicationDataService(DefaultDbContext context)
{
    private readonly DefaultDbContext _context = context;

    public async Task<List<Application>> GetAllApplicationsAsync()
    {
        return await _context.Applications
                             .Include(a => a.Internship)
                                .ThenInclude(i => i.Student)
                             .Include(a => a.Internship)
                                .ThenInclude(i => i.Company)
                             .Include(a => a.Student)
                             .ToListAsync();
    }

    public async void AddApplicationAsync(Application application)
    {
        _context.Applications.Add(application);
        await _context.SaveChangesAsync();
    }

    public async void UpdateApplicationAsync(Application application)
    {
        _context.Applications.Update(application);
        await _context.SaveChangesAsync();
    }

    public async void DeleteApplicationAsync(Application application)
    {
        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();
    }
}
