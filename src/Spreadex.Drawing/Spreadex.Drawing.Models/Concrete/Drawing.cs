using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Extensions;

namespace Spreadex.Drawing.Models.Concrete;

public class Drawing: IDrawing
{
    private readonly List<IWidget> _widgets = new();

    public void AddWidget(IWidget widget)
    {
        _widgets.Add(widget);
    }

    public void PrintDrawing()
    {
        var widgetDetails = _widgets.ToWidgetDetailsList().ToArray();
        var longestWidgetDetailsStringLength = widgetDetails.Select(x => x.Length).Max();
        var longHyphenString = new string('-', longestWidgetDetailsStringLength + 5);
        
        Console.WriteLine(longHyphenString);
        Console.WriteLine("Requested Drawing");
        Console.WriteLine(longHyphenString);
        
        foreach (var predefinedWidget in widgetDetails)
        {
            Console.WriteLine(predefinedWidget);
        };
        Console.WriteLine(longHyphenString);
    }
}