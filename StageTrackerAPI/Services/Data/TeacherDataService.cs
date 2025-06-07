using Microsoft.EntityFrameworkCore;
using StageTracker.API.Data;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.API.Services.Data
{
    public class TeacherDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.Include(t => t.Classe).ToListAsync();
        }

        public async void AddTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async void UpdateTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public async void DeleteTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
