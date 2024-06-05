using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Entities;
using System.Reflection;

namespace MyProject.DataAccess.Context;

public interface IDataBaseContext
{
    public DbSet<User> Users { get; set; }

}

public class DataBaseContext : DbContext, IDataBaseContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {

        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
