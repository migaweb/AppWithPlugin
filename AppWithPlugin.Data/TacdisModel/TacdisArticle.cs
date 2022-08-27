using System.ComponentModel.DataAnnotations;

namespace AppWithPlugin.Data.TacdisModel;

public class TacdisArticle
{
  public int Id { get; set; }
  public string? TacdisId { get; set; }

  public int ArticleId { get; set; }
  public Model.Article Article { get; set; } = new Model.Article();
}
