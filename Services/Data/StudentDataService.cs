using Microsoft.EntityFrameworkCore;
using StageTracker.Data;
using StageTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.Services.Data
{
    public class StudentDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(s => s.Classe).ToListAsync();
        }
    }
}
