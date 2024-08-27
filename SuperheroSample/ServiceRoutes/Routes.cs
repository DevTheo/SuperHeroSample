using SuperheroSample.ServiceRoutes.Handlers;

namespace SuperheroSample.ServiceRoutes;

public static class Routes
{
    public static WebApplication AddServiceRoutes(this WebApplication app)
    {
        app.MapGet("/set-name", MainHandler.SetNameAsync);
        return app;
    } 
}