using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SuperheroSample.Components.Widgets;
using SuperheroSample.Components.Widgets.Home;
using SuperheroSample.Components.Widgets.SuperHero;
using SuperheroSample.Repositories;

namespace SuperheroSample.ServiceRoutes.Handlers;

public class MainHandler
{
    // These methods can accept injected dependencies
    public static RazorComponentResult<HomeChildContent> SetNameAsync(string visitorName)
    {
        return new RazorComponentResult<HomeChildContent>(
        new {
            VisitorName = visitorName
        });
    }

    public static async Task<RazorComponentResult<SuperHeroContent>> SearchForHero(ISuperHeroDataRepository repo, string heroName)
    {
        var hero = await repo.GetSuperHeroByNameAsync(heroName);
        
        return new RazorComponentResult<SuperHeroContent>(new { SuperHero = hero });
    }
}