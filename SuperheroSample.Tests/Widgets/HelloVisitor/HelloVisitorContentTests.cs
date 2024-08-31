using Bunit;
using SuperheroSample.Components.Widgets.HelloVisitor;

namespace SuperheroSample.Tests;

public class HelloVisitorContentTests
{
    private static IRenderedComponent<HelloVisitorContent> Render(TestContext context, string visitorName)
    {
        return context.RenderComponent<HelloVisitorContent>(paramBuilder => paramBuilder
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