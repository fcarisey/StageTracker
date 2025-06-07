using Microsoft.EntityFrameworkCore;
using StageTracker.API.Data;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.API.Services.Data
{
    public class RemarkDataService(DefaultDbContext context)
    {
        private readonly DefaultDbContext _context = context;

        public async Task<List<RemarkDto>> GetAllRemarksAsync()
        {
            return await _context.Remarks.ToListAsync();
        }

        public async void AddRemarkAsync(RemarkDto remark)
        {
            _context.Remarks.Add(remark);
            await _context.SaveChangesAsync();
        }

        public async void UpdateRemarkAsync(RemarkDto remark)
        {
            _context.Remarks.Update(remark);
            await _context.SaveChangesAsync();
        }

        public async void DeleteRemarkAsync(RemarkDto remark)
        {
            _context.Remarks.Remove(remark);
            await _context.SaveChangesAsync();
        }
    }
}
