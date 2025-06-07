using Microsoft.EntityFrameworkCore;
using StageTrackerAPI.Data;
using StageTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTrackerAPI.Services.Data
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
