namespace Spreadex.Drawing.Models.Utils;

internal static class StringUtils
{
    public static string WidgetPropertyToString<T>(string propName,T propVal) => $"{propName}={propVal}"; 
}