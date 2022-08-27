namespace AppWithPlugin.Services.Dtos;

public class Article<T> where T : IPluginArticle
{
  public int Id { get; set; }
  public string? ShortText { get; set; }

  public T? PluginArticle { get; set; }
}

public interface IPluginArticle
{

}

public class NoPluginArticle : IPluginArticle
{

}

public class ErmArticle : IPluginArticle
{
  public string? CodaIdentifier { get; set; }
}

public class TacdisArticle : IPluginArticle
{
  public string? TacdisId { get; set; }
}
