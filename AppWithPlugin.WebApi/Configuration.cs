using AppWithPlugin.Data;
using AppWithPlugin.Services;
using Microsoft.EntityFrameworkCore;

namespace AppWithPlugin.WebApi;

public static class Configuration
{
  public static void ConfigureDbAndServices(this IServiceCollection services)
  {
    services.AddScoped(typeof(IArticleService<>), typeof(CoreArticleService<>));

    // Article core
    services.AddScoped<ArticleService>();

    services.AddDbContext<CoreDbContext>((options) =>
    {
      options.UseInMemoryDatabase(databaseName: "core");
    }
      );


    // Erm Article
    services.AddScoped<ErmArticleService>();

    services.AddDbContext<ErmDbContext>((options) =>
    {
      options.UseInMemoryDatabase(databaseName: "erm");
    }
    );

    // Tacdis Article
    services.AddScoped<TacdisArticleService>();

    services.AddDbContext<TacdisDbContext>((options) =>
    {
      options.UseInMemoryDatabase(databaseName: "tacdis");
    }
    );
  }
}
