using System.Text;
using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Extensions;
using Spreadex.Drawing.Models.Utils;

namespace Spreadex.Drawing.Models.Concrete;

public class TextboxWidget: BaseWidget
{
    public required RectangleWidget BoundingRectangle { get; init; }
    public required string Text { get; init; }
    public override string GetDetails()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"{TypeName} ({Location.X}, {Location.Y}) ");
        stringBuilder.Append(BoundingRectangle.GetUniqueWidgetDetails());
        stringBuilder.Append(' ');
        stringBuilder.Append(StringUtils.WidgetPropertyToString(nameof(Text), Text));
        
        return stringBuilder.ToString();
    }
}