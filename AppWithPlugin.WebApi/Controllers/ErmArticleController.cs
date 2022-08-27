using AppWithPlugin.Services;
using AppWithPlugin.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWithPlugin.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ErmArticleController : ArticleController<ErmArticle>
  {
    public ErmArticleController(ILogger<ArticleController<ErmArticle>> logger, ErmArticleService articleService) 
      : base(logger, articleService)
    {
    }
  }
}
