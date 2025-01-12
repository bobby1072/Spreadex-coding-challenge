using System.Drawing;
using Spreadex.Drawing.App.Services.Abstract;
using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.App.Services.Concrete;

public class WidgetFactory: IWidgetFactory
{
    public IWidget CreateRectangle(int x, int y, int width, int height) => new RectangleWidget
    {
        Height = height, Location = new PageLocation
        {
            X = x,
            Y = y
        },
        Width = width
    };

    public IWidget CreateCircle(int x, int y, int diameter) => new CircleWidget
    {
        Diameter = diameter,
        Location = new PageLocation
        {
            X = x,
            Y = y
        }
    };

    public IWidget CreateEllipse(int x, int y, int horizontalDiameter, int verticalDiameter) => new EllipseWidget
    {
        Location = new PageLocation
        {
            X = x,
            Y = y
        },
        HorizontalDiameter = horizontalDiameter,
        VerticalDiameter = verticalDiameter
    };

    public IWidget CreateSquare(int x, int y, int width) => new SquareWidget
    {
        Location = new PageLocation
        {
            X = x,
            Y = y

        },
        Width = width
    };

    public IWidget CreateTextbox(int x, int y, string text, RectangleWidget rectangle) => new TextboxWidget
    {
        Location = new PageLocation
        {
            X = x,
            Y = y
        },
        Text = text,
        BoundingRectangle = rectangle,

    };
}