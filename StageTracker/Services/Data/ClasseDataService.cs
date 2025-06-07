using Microsoft.EntityFrameworkCore;
using StageTracker.WPF.Data;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.WPF.Services.Data
{
    public class ClasseDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<Classe>> GetAllClassesAsync()
        {
            return await _context.Classes.Include(c => c.Teacher).ToListAsync();
        }

        public async void AddClasseAsync(Classe classe)
        {
            _context.Classes.Add(classe);
            await _context.SaveChangesAsync();
        }

        public async void UpdateClasseAsync(Classe classe)
        {
            _context.Classes.Update(classe);
            await _context.SaveChangesAsync();
        }

        public async void DeleteClasseAsync(Classe classe)
        {
            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
        }
    }
}
