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
            .Select(x => WidgetUtils.WidgetPropertyToString(x.Name, x.GetValue(widget)));

        return string.Join(" ", uniqueProperties);
    }

    public static string GetWidgetTypeName(this IWidget widget) => widget.GetType().Name.Replace("Widget", "");
    public static IEnumerable<string> ToWidgetDetailsList(this IEnumerable<IWidget> widgets)
    {
        foreach (var widg in widgets)
        {
            yield return widg.GetDetails();
        }
    }
}