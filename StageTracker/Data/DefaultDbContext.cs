using Microsoft.EntityFrameworkCore;
using StageTracker.Models;

namespace StageTracker.Data;

public class DefaultDbContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Classe> Classes => Set<Classe>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Intership> Internships => Set<Intership>();
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Remark> Remarks => Set<Remark>();

    public DefaultDbContext() { }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
        
    }
}
