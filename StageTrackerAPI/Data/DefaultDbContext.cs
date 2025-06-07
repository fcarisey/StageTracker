using Microsoft.EntityFrameworkCore;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.API.Data;

public class DefaultDbContext : DbContext
{
    public DbSet<Application> Applications { get; set; } = null!;
    public DbSet<Internship> Internships { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Classe> Classes { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Remark> Remarks { get; set; } = null!;

    public DefaultDbContext(DbContextOptions options) : base(options)
    {
    }
}
