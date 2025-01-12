using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Spreadex.Drawing.App.Services.Concrete;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.App.Tests;

public class WidgetFactoryTests
{
    private readonly Mock<IServiceProvider> _serviceProviderMock;
    private readonly WidgetFactory _widgetFactory;

    public WidgetFactoryTests()
    {
        _serviceProviderMock = new Mock<IServiceProvider>();

        _widgetFactory = new WidgetFactory(_serviceProviderMock.Object);
    }
    [Fact]
    public void CreateRectangle_ShouldReturnValidRectangle()
    {
        // Arrange
        var x = 10;
        var y = 20;
        var width = 30;
        var height = 40;

        // Act
        var rectangle = _widgetFactory.CreateRectangle(x, y, width, height);

        // Assert
        rectangle.Should().BeOfType<RectangleWidget>();
        var rect = rectangle as RectangleWidget;
        rect.Should().NotBeNull();
        rect!.Height.Should().Be(height);
        rect.Width.Should().Be(width);
        rect.Location.X.Should().Be(x);
        rect.Location.Y.Should().Be(y);
    }

    [Fact]
    public void CreateCircle_ShouldReturnValidCircle()
    {
        // Arrange
        var x = 15;
        var y = 25;
        var diameter = 50;

        // Act
        var circle = _widgetFactory.CreateCircle(x, y, diameter);

        // Assert
        circle.Should().BeOfType<CircleWidget>();
        var circ = circle as CircleWidget;
        circ.Should().NotBeNull();
        circ!.Diameter.Should().Be(diameter);
        circ.Location.X.Should().Be(x);
        circ.Location.Y.Should().Be(y);
    }

    [Fact]
    public void CreateSquare_ShouldReturnValidSquare()
    {
        // Arrange
        var x = 5;
        var y = 10;
        var width = 20;

        // Act
        var square = _widgetFactory.CreateSquare(x, y, width);

        // Assert
        square.Should().BeOfType<SquareWidget>();
        var sq = square as SquareWidget;
        sq.Should().NotBeNull();
        sq!.Width.Should().Be(width);
        sq.Location.X.Should().Be(x);
        sq.Location.Y.Should().Be(y);
    }

    [Fact]
    public void CreateTextbox_ShouldReturnValidTextbox()
    {
        // Arrange
        var x = 5;
        var y = 10;
        var text = "Sample Text";
        var boundingRectangle = new RectangleWidget
        {
            Height = 100,
            Width = 200,
            Location = new PageLocation { X = 1, Y = 1 }
        };

        // Act
        var textbox = _widgetFactory.CreateTextbox(x, y, text, boundingRectangle);

        // Assert
        textbox.Should().BeOfType<TextboxWidget>();
        var tb = textbox as TextboxWidget;
        tb.Should().NotBeNull();
        tb!.Text.Should().Be(text);
        tb.BoundingRectangle.Should().Be(boundingRectangle);
        tb.Location.X.Should().Be(x);
        tb.Location.Y.Should().Be(y);
    }

    [Fact]
    public void CreateEllipse_ShouldReturnValidEllipse()
    {
        // Arrange
        var x = 20;
        var y = 30;
        var horizontalDiameter = 50;
        var verticalDiameter = 60;

        // Act
        var ellipse = _widgetFactory.CreateEllipse(x, y, horizontalDiameter, verticalDiameter);

        // Assert
        ellipse.Should().BeOfType<EllipseWidget>();
        var ell = ellipse as EllipseWidget;
        ell.Should().NotBeNull();
        ell!.HorizontalDiameter.Should().Be(horizontalDiameter);
        ell.VerticalDiameter.Should().Be(verticalDiameter);
        ell.Location.X.Should().Be(x);
        ell.Location.Y.Should().Be(y);
    }
}