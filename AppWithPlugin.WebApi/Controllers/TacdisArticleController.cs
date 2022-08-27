using AppWithPlugin.Services;
using AppWithPlugin.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWithPlugin.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TacdisArticleController : ArticleController<TacdisArticle>
  {
    public TacdisArticleController(ILogger<ArticleController<TacdisArticle>> logger, TacdisArticleService articleService) 
      : base(logger, articleService)
    {
    }
  }
}
