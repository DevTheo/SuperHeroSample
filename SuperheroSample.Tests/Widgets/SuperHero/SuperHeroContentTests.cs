using Bunit;
using SuperheroSample.Components.Widgets.SuperHero;

namespace SuperheroSample.Tests.Widgets.SuperHero;

public class SuperHeroContentTests
{
    private static IRenderedComponent<SuperHeroContent> Render(TestContext context, List<Repositories.SuperHero> superHeroes)
    {
        return context.RenderComponent<SuperHeroContent>(paramBuilder => paramBuilder
            .Add(p => p.SuperHeroes, superHeroes));
    }

    [Fact]
    public void Render_should_render_heros_that_are_passed_in()
    {
        List<Repositories.SuperHero> heros = [
            new(1, "Superman", "blue", "black", 1_000_000l, "first appearance", "first appearance 1939")
        ];
        using var context = new TestContext();
        var cut = Render(context, heros);
        
        Assert.Contains("Superman", cut.Markup);
    }
}