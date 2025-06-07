using Microsoft.EntityFrameworkCore;
using StageTracker.Shared.ModelsEF;

namespace StageTracker.WPF.Data;

public class DefaultDbContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Classe> Classes => Set<Classe>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Internship> Internships => Set<Internship>();
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Remark> Remarks => Set<Remark>();

    public DefaultDbContext() { }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
        
    }
}
