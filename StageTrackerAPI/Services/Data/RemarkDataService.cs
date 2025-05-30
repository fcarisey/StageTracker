using Microsoft.EntityFrameworkCore;
using StageTrackerAPI.Data;
using StageTrackerAPI.Models;

namespace StageTrackerAPI.Services.Data
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
