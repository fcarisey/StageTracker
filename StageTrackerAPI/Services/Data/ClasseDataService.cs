using Microsoft.EntityFrameworkCore;
using StageTracker.API.Data;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.API.Services.Data
{
    public class ClasseDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<ClasseDto>> GetAllClassesAsync()
        {
            return await _context.Classes.Include(c => c.Teacher).ToListAsync();
        }

        public async void AddClasseAsync(ClasseDto classe)
        {
            _context.Classes.Add(classe);
            await _context.SaveChangesAsync();
        }

        public async void UpdateClasseAsync(ClasseDto classe)
        {
            _context.Classes.Update(classe);
            await _context.SaveChangesAsync();
        }

        public async void DeleteClasseAsync(ClasseDto classe)
        {
            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
        }
    }
}
