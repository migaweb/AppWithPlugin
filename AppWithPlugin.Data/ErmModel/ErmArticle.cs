using System.ComponentModel.DataAnnotations;

namespace AppWithPlugin.Data.ErmModel;

public class ErmArticle
{
  public int Id { get; set; }
  public string? CodaIdentifier { get; set; }

  public int ArticleId { get; set; }
  public Model.Article Article { get; set; } = new Model.Article();
}
