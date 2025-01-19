using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Utils;
using System.Reflection;

namespace Spreadex.Drawing.Models.Extensions;

internal static class WidgetExtensions
{
    private static readonly IReadOnlyCollection<PropertyInfo> _widgetInterfaceProperties =
        typeof(IWidget).GetProperties();

    public static string GetUniqueWidgetDetails<T>(this T widget)
        where T : class, IWidget
    {
        var widgetType = widget.GetType();
        var uniqueProperties = widgetType
            .GetProperties()
            .Where(x => _widgetInterfaceProperties.All(y => y.Name != x.Name))
            .Select(x => WidgetUtils.WidgetPropertyToString(x.Name, x.GetValue(widget)))
            .ToArray();

        return string.Join(' ', uniqueProperties);
    }

    public static string GetWidgetTypeName<T>(this T widget)
        where T : class, IWidget => widget.GetType().Name.Replace("Widget", "");

    public static IEnumerable<string> ToWidgetDetailsList(this IEnumerable<IWidget> widgets)
    {
        foreach (var widget in widgets)
        {
            yield return widget.GetDetails();
        }
    }
}
