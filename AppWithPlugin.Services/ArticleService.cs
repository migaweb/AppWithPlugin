global using AppWithPlugin.Data;
using AppWithPlugin.Services.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AppWithPlugin.Services;

public interface IArticleService<T> where T : IPluginArticle
{
  Article<T> MapArticle(Data.Model.Article article);
  List<Article<T>> GetArticles();
  Article<T>? GetArticle(int id);
}

public class CoreArticleService<T> : IArticleService<T> where T : IPluginArticle
{
  private readonly CoreDbContext _coreDbContext;

  public CoreArticleService(CoreDbContext coreDbContext)
  {
    _coreDbContext = coreDbContext;
  }

  public virtual Article<T>? GetArticle(int id)
  {
    var article = _coreDbContext.Articles.Where(e => e.Id == id).FirstOrDefault();

    if (article == null) return null;

    return MapArticle(article);
  }

  public virtual List<Article<T>> GetArticles()
  {
    var articles = _coreDbContext.Articles.ToList();

    return articles.Select(e => MapArticle(e)).ToList();
  }

  public virtual Article<T> MapArticle(Data.Model.Article article)
  {
    return new Article<T>
    {
      Id = article.Id,
      ShortText = article.ShortText
    };
  }

  public virtual void Save()
  {
    _coreDbContext.SaveChanges();
  }
}

public class ErmArticleService : CoreArticleService<ErmArticle>, IArticleService<ErmArticle>
{
  private readonly IArticleService<ErmArticle> _articleService;
  private readonly ErmDbContext _ermDbContext;

  public ErmArticleService(IArticleService<ErmArticle> articleService, ErmDbContext ermDbContext) : base (ermDbContext)
  {
    _articleService = articleService;
    _ermDbContext = ermDbContext;
  }

  public override Article<ErmArticle>? GetArticle(int id)
  {
    var article = _ermDbContext.ErmArticles.Include(e => e.Article)
      .Where(e => e.ArticleId == id).FirstOrDefault();

    if (article == null) return null;

    return MapArticle(article);
  }

  public Article<ErmArticle> MapArticle(Data.ErmModel.ErmArticle article)
  {
    var result = _articleService.MapArticle(article.Article);
    result.PluginArticle = new ErmArticle { CodaIdentifier = article.CodaIdentifier };

    return result;
  }

  public string SpecialExport()
  {
    return System.Text.Json.JsonSerializer.Serialize(
      _ermDbContext.ErmArticles.Include(e => e.Article).ToList()
    );
  }

  public override void Save()
  {
    _ermDbContext.SaveChanges();
  }
}

public class TacdisArticleService : CoreArticleService<TacdisArticle>, IArticleService<TacdisArticle>
{
  private readonly IArticleService<TacdisArticle> _articleService;
  private readonly TacdisDbContext _tacdisDbContext;

  public TacdisArticleService(IArticleService<TacdisArticle> articleService, TacdisDbContext tacdisDbContext)
    : base(tacdisDbContext)
  {
    _articleService = articleService;
    _tacdisDbContext = tacdisDbContext;
  }

  public override Article<TacdisArticle>? GetArticle(int id)
  {
    var article = _tacdisDbContext.TacdisArticles.Include(e => e.Article)
      .Where(e => e.ArticleId == id).FirstOrDefault();

    if (article == null) return null;

    return MapArticle(article);
  }

  public Article<TacdisArticle> MapArticle(Data.TacdisModel.TacdisArticle article)
  {
    var result = _articleService.MapArticle(article.Article);
    result.PluginArticle = new TacdisArticle { TacdisId = article.TacdisId };

    return result;
  }

  public override void Save()
  {
    _tacdisDbContext.SaveChanges();
  }
}

public class ArticleService : CoreArticleService<CoreArticle>
{
  public ArticleService(CoreDbContext coreDbContext) : base(coreDbContext)
  {

  }
}
