using SuperheroSample.ServiceRoutes.Handlers;

namespace SuperheroSample.ServiceRoutes;

public static class Routes
{
    public static WebApplication AddServiceRoutes(this WebApplication app)
    {
        app.MapGet("/api/set-name", MainHandler.SetNameAsync);
        app.MapGet("/api/superheroes/search", MainHandler.SearchForHeroes);
        app.MapGet("/api/superheroes/{id}", MainHandler.GetHero);
        return app;
    } 
}