using Microsoft.EntityFrameworkCore;

namespace AppWithPlugin.Data;

public class CoreDbContext : DbContext
{
  public DbSet<Model.Article> Articles { get; set; }

  public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

  }
}
