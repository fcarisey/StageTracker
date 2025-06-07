using Microsoft.EntityFrameworkCore;
using StageTracker.WPF.Data;
using StageTracker.Shared.ModelsEF;
using System.Diagnostics;

namespace StageTracker.WPF.Services.Data
{
    public class StudentDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(s => s.Classe).ToListAsync();
        }

        public async Task<List<Student>?> GetStudentsByClasseAsync(int id)
        {
            try
            {
                var a = await _context.Students
                                 .Include(s => s.Classe)
                                 .Include(s => s.Remarks)
                                 .Include(s => s.Applications)
                                    .ThenInclude(a => a.Internship)
                                        .ThenInclude(i => i.Company)
                                 .Where(s => s.ClasseId == id)
                                 .ToListAsync();

                return await _context.Students
                                 .Include(s => s.Classe)
                                 .Include(s => s.Remarks)
                                 .Include(s => s.Applications)
                                    .ThenInclude(a => a.Internship)
                                        .ThenInclude(i => i.Company)
                                 .Where(s => s.ClasseId == id)
                                 .ToListAsync();
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error fetching students by class: {ex.Message} : {ex.Source}");
                return null;
            }

        }

        public async void AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async void UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async void DeleteStudentAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
