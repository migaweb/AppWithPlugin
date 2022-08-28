using AppWithPlugin.Services;
using AppWithPlugin.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AppWithPlugin.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoreArticleController : ArticleController<CoreArticle>
{
  public CoreArticleController(ILogger<ArticleController<CoreArticle>> logger, ArticleService articleService) : base(logger, articleService)
  {
  }
}
