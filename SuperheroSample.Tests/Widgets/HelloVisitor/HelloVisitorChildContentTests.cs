using Bunit;
using SuperheroSample.Components.Widgets.HelloVisitor;

namespace SuperheroSample.Tests;

public class HelloVisitorChildContentTests
{
    private static IRenderedComponent<HelloVisitorChildContent> Render(TestContext context, string visitorName)
    {
        return context.RenderComponent<HelloVisitorChildContent>(paramBuilder => paramBuilder
            .Add(p => p.VisitorName, visitorName));
    }
    [Fact]
    public void Render_should_render_hello_and_name()
    {
        using var context = new TestContext();
        var cut = Render(context, "John Doe");
        Assert.Contains("Hello, John Doe!", cut.Markup);
    }
}