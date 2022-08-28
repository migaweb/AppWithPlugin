using Microsoft.EntityFrameworkCore;

namespace AppWithPlugin.Data;

public class ErmDbContext : CoreDbContext
{
  public DbSet<ErmModel.ErmArticle> ErmArticles { get; set; } = null!;

  public ErmDbContext(DbContextOptions<CoreDbContext> options) : base(options)
  {
    //https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontextoptions-versus-dbcontextoptionstcontext
    //https://stackoverflow.com/questions/41829229/how-do-i-implement-dbcontext-inheritance-for-multiple-databases-in-ef7-net-co
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ErmModel.ErmArticle>().HasOne(i => i.Article);
  }
}
