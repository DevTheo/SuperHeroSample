using Microsoft.AspNetCore.Http.HttpResults;
using SuperheroSample.Components.Widgets.SuperHero;
using SuperheroSample.Components.Widgets.HelloVisitor;
using SuperheroSample.Repositories;

namespace SuperheroSample.ServiceRoutes.Handlers;

public class MainHandler
{
    // These methods can accept injected dependencies
    public static RazorComponentResult<HelloVisitorChildContent> SetNameAsync(string visitorName)
    {
        return new RazorComponentResult<HelloVisitorChildContent>(
        new {
            VisitorName = visitorName
        });
    }

    public static async Task<RazorComponentResult<SuperHeroContent>> SearchForHeroes(ISuperHeroDataRepository repo, string heroName)
    {
        var heroes = await repo.GetSuperHeroesByNameAsync(heroName);
        
        return new RazorComponentResult<SuperHeroContent>(new { SuperHeroes = heroes });
    }
    public static async Task<RazorComponentResult<SuperHeroContentDetails>> GetHero(ISuperHeroDataRepository repo, int id)
    {
        var hero = await repo.GetSuperHeroByIdAsync(id);
        
        return new RazorComponentResult<SuperHeroContentDetails>(new { SuperHero = hero });
    }
}