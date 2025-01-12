using Spreadex.Drawing.Models.Abstract;

namespace Spreadex.Drawing.Models.Concrete;

public class RectangleWidget : BaseWidget
{
    public required int Width { get; init; }
    public required int Height { get; init; }
}
