using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Extensions;
using System.Text;

namespace Spreadex.Drawing.Models.Abstract;

public abstract class BaseWidget : IWidget
{
    public virtual string TypeName => this.GetWidgetTypeName();
    public required PageLocation Location { get; init; }

    public virtual string GetDetails()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"{TypeName} ({Location.X}, {Location.Y}) ");
        stringBuilder.Append(this.GetUniqueWidgetDetails());

        return stringBuilder.ToString();
    }
}
