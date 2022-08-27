using AppWithPlugin.Services;
using AppWithPlugin.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWithPlugin.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CoreArticleController : ArticleController<NoPluginArticle>
  {
    public CoreArticleController(ILogger<ArticleController<NoPluginArticle>> logger, ArticleService articleService) : base(logger, articleService)
    {
    }
  }
}
