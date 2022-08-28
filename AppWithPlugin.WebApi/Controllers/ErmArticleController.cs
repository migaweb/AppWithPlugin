using AppWithPlugin.Services;
using AppWithPlugin.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AppWithPlugin.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ErmArticleController : ArticleController<ErmArticle>
{
  private readonly ErmArticleService _articleService;

  public ErmArticleController(ILogger<ArticleController<ErmArticle>> logger, ErmArticleService articleService) 
    : base(logger, articleService)
  {
    _articleService = articleService;
  }

  [HttpGet("SpecialExport")]
  public IActionResult SpecialExport()
  {
    return Ok(_articleService.SpecialExport());
  }
}
