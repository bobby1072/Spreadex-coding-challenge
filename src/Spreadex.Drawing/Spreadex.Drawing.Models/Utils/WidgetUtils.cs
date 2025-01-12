namespace Spreadex.Drawing.Models.Utils;

internal static class WidgetUtils
{
    public static string WidgetPropertyToString<T>(string propName, T propVal) =>
        $"{propName}={propVal}";
}
