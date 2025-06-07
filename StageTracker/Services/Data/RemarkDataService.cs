using Microsoft.EntityFrameworkCore;
using StageTracker.WPF.Data;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.WPF.Services.Data
{
    public class RemarkDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<Remark>> GetAllRemarksAsync()
        {
            return await _context.Remarks.ToListAsync();
        }

        public async void AddRemarkAsync(Remark remark)
        {
            _context.Remarks.Add(remark);
            await _context.SaveChangesAsync();
        }

        public async void UpdateRemarkAsync(Remark remark)
        {
            _context.Remarks.Update(remark);
            await _context.SaveChangesAsync();
        }

        public async void DeleteRemarkAsync(Remark remark)
        {
            _context.Remarks.Remove(remark);
            await _context.SaveChangesAsync();
        }
    }
}
