using Spreadex.Drawing.Models.Abstract;

namespace Spreadex.Drawing.App.Extensions;

public static class WidgetExtensions
{
    public static IEnumerable<string> ToWidgetDetailsList(this IEnumerable<IWidget> widgets)
    {
        foreach (var widg in widgets)
        {
            yield return widg.GetDetails();
        }
    }
}