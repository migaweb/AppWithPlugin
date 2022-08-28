using AppWithPlugin.Services;
using AppWithPlugin.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AppWithPlugin.WebApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ArticleController<T> : ControllerBase where T : IPluginArticle
  {
    private readonly ILogger<ArticleController<T>> _logger;
    private readonly IArticleService<T> _articleService;

    public ArticleController(ILogger<ArticleController<T>> logger, IArticleService<T> articleService)
    {
      _logger = logger;
      _articleService = articleService;
      logger.LogInformation(nameof(T));
    }

    [HttpGet("Get")]
    public IActionResult Get()
    {
      return Ok(_articleService.GetArticles());
    }

    [HttpGet("GetArticle")]
    public IActionResult GetArticle(int id)
    {
      return Ok(_articleService.GetArticle(id));
    }
  }
}