using Microsoft.EntityFrameworkCore;

namespace AppWithPlugin.Data;

public class TacdisDbContext : CoreDbContext
{
  public DbSet<TacdisModel.TacdisArticle> TacdisArticles { get; set; } = null!;

  public TacdisDbContext(DbContextOptions<CoreDbContext> options) : base(options)
  {
    //https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontextoptions-versus-dbcontextoptionstcontext
    //https://stackoverflow.com/questions/41829229/how-do-i-implement-dbcontext-inheritance-for-multiple-databases-in-ef7-net-co
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<TacdisModel.TacdisArticle>().HasOne(i => i.Article);
  }
}
