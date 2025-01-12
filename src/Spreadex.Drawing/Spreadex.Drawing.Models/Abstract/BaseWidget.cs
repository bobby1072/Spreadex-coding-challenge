using System.Text;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.Models.Abstract;

public abstract class BaseWidget: IWidget
{
    private Type _widgetType => GetType();
    public virtual string TypeName => GetTypeName();
    public required PageLocation Location { get; init; }
    public virtual string GetDetails()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"{TypeName} ({Location.X}, {Location.Y}) ");
        stringBuilder.Append(GetUniqueWidgetDetails());
        
        return stringBuilder.ToString();
    }

    private string GetUniqueWidgetDetails()
    {
        var widgetInterfaceProperties = typeof(IWidget).GetProperties();
        var uniqueProperties = _widgetType
            .GetProperties()
            .Where(x => widgetInterfaceProperties.All(y => y.Name != x.Name))
            .Select(x => $"{x.Name}={x.GetValue(this)}");

        return string.Join(" ", uniqueProperties);
    }
    private string GetTypeName()
    {
        return _widgetType.Name.Replace("Widget", "");
    }
}