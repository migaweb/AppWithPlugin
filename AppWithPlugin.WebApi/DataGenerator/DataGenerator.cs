using AppWithPlugin.Data;

namespace AppWithPlugin.WebApi.DataGenrator;

public static class DataGenerator
{
  public static void Initialize(this IServiceProvider serviceProvider)
  {
    SeedCore(serviceProvider);
    SeedErm(serviceProvider);
    SeedTacdis(serviceProvider);
  }

  private static void SeedErm(IServiceProvider serviceProvider)
  {
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ErmDbContext>();

    if (context.Articles.Any())
    {
      return;
    }

    context.ErmArticles.AddRange(
      new Data.ErmModel.ErmArticle()
      {
        Id = 1,
        Article = new Data.Model.Article() { Id = 1, ShortText = "1956515" },
        ArticleId = 1,
        CodaIdentifier =  "Coda 1"
      },
      new Data.ErmModel.ErmArticle()
      {
        Id = 2,
        Article = new Data.Model.Article() { Id = 2, ShortText = "2055516" },
        ArticleId = 2,
        CodaIdentifier = "Coda 2"
      }
    );

    context.SaveChanges();
  }

  private static void SeedTacdis(IServiceProvider serviceProvider)
  {
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<TacdisDbContext>();

    if (context.Articles.Any())
    {
      return;
    }

    context.TacdisArticles.AddRange(
      new Data.TacdisModel.TacdisArticle() 
      { 
        Id = 1, 
        Article = new Data.Model.Article() { Id = 1, ShortText = "1956515" },
        ArticleId = 1,
        TacdisId = "TAC1"       
      },
      new Data.TacdisModel.TacdisArticle() 
      { 
        Id = 2, 
        Article = new Data.Model.Article() { Id = 2, ShortText = "2055516" },  
        ArticleId = 2, 
        TacdisId = "TAC2" 
      }
    );

    context.SaveChanges();
  }

  private static void SeedCore(IServiceProvider serviceProvider)
  {
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<CoreDbContext>();

    if (context.Articles.Any())
    {
      return;
    }

    context.Articles.AddRange(
      new Data.Model.Article() { Id = 1, ShortText = "1956515" },
      new Data.Model.Article() { Id = 2, ShortText = "2055516" }
    );


    context.SaveChanges();
  }
}
