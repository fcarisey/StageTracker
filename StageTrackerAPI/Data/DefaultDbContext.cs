using Microsoft.EntityFrameworkCore;

namespace StageTrackerAPI.Data;

public class DefaultDbContext : DbContext
{
    public DbSet<Models.Application> Applications { get; set; } = null!;
    public DbSet<Models.IntershipDto> Internships { get; set; } = null!;
    public DbSet<Models.Student> Students { get; set; } = null!;
    public DbSet<Models.CompanyDto> Companies { get; set; } = null!;
    public DbSet<Models.User> Users { get; set; } = null!;
    public DbSet<Models.ClasseDto> Classes { get; set; } = null!;
    public DbSet<Models.Teacher> Teachers { get; set; } = null!;
    public DbSet<Models.RemarkDto> Remarks { get; set; } = null!;

    public DefaultDbContext(DbContextOptions options) : base(options)
    {
    }
}
