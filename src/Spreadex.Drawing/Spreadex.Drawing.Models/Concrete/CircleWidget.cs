using Spreadex.Drawing.Models.Abstract;

namespace Spreadex.Drawing.Models.Concrete;

public class CircleWidget: BaseWidget
{
    public required int Diameter { get; init; }
}