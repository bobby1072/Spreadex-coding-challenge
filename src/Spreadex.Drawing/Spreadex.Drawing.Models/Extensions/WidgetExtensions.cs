using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Utils;

namespace Spreadex.Drawing.Models.Extensions;

internal static class WidgetExtensions
{
    public static string GetUniqueWidgetDetails<T>(this T widget) where T : IWidget
    {
        var widgetType = widget.GetType();
        var widgetInterfaceProperties = typeof(IWidget).GetProperties();
        var uniqueProperties = widgetType
            .GetProperties()
            .Where(x => widgetInterfaceProperties.All(y => y.Name != x.Name))
            .Select(x => StringUtils.WidgetPropertyToString(x.Name, x.GetValue(widget)));

        return string.Join(" ", uniqueProperties);
    }

    public static string GetWidgetTypeName<T>(this T widget) where T: IWidget => widget.GetType().Name.Replace("Widget", "");
    public static IEnumerable<string> ToWidgetDetailsList<T>(this IEnumerable<T> widgets) where T: IWidget
    {
        foreach (var widg in widgets)
        {
            yield return widg.GetDetails();
        }
    }
}