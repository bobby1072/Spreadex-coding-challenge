using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.App.Services.Abstract;

public interface IWidgetFactory
{
    IWidget CreateRectangle(int x, int y, int width, int height);
    IWidget CreateCircle(int x, int y, int diameter);
    IWidget CreateEllipse(int x, int y, int horizontalDiameter, int verticalDiameter);
    IWidget CreateSquare(int x, int y, int width);
    IWidget CreateTextbox(int x, int y, string text, RectangleWidget rectangle);
}