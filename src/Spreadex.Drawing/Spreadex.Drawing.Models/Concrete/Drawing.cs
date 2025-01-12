using Spreadex.Drawing.Models.Abstract;

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
        Console.WriteLine("Drawing:");
        foreach (var widget in _widgets)
        {
            Console.WriteLine(widget.GetDetails());
        }
    }
}