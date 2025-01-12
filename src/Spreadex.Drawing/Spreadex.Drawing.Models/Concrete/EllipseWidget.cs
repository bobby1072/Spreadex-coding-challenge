using Spreadex.Drawing.Models.Abstract;

namespace Spreadex.Drawing.Models.Concrete;

public class EllipseWidget: BaseWidget
{
    public required int HorizontalDiameter { get; init; }
    public required int VerticalDiameter { get; init; }
}