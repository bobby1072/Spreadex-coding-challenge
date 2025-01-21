using Spreadex.Drawing.App.Abstract;
using Spreadex.Drawing.App.Services.Abstract;
using Spreadex.Drawing.App.Services.Concrete;
using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.App.Concrete;

public class App : IApp
{
    private readonly IDrawing _drawing;
    private readonly IWidgetFactory _widgetFactory;

    public App(IDrawing drawing, IWidgetFactory widgetFactory)
    {
        _drawing = drawing;
        _widgetFactory = widgetFactory;
    }

    public void Run()
    {
        IReadOnlyCollection<IWidget> predefinedWidgetDetailsList =
        [
            _widgetFactory.CreateWidget<RectangleWidget>(
                new PageLocation { X = 10, Y = 10 },
                (nameof(RectangleWidget.Width), 30),
                (nameof(RectangleWidget.Height), 40)
            ),
            _widgetFactory.CreateWidget<SquareWidget>(
                new PageLocation { X = 15, Y = 30 },
                (nameof(SquareWidget.Width), 35)
            ),
            _widgetFactory.CreateWidget<EllipseWidget>(
                new PageLocation { X = 100, Y = 150 },
                (nameof(EllipseWidget.HorizontalDiameter), 300),
                (nameof(EllipseWidget.VerticalDiameter), 200)
            ),
            _widgetFactory.CreateWidget<CircleWidget>(
                new PageLocation { X = 1, Y = 1 },
                (nameof(CircleWidget.Diameter), 300)
            ),
            _widgetFactory.CreateWidget<TextboxWidget>(
                new PageLocation { X = 5, Y = 5 },
                (nameof(TextboxWidget.Text), "sample text"),
                (
                    nameof(TextboxWidget.BoundingRectangle),
                    _widgetFactory.CreateWidget<RectangleWidget>(
                        new PageLocation { X = 5, Y = 5 },
                        (nameof(RectangleWidget.Width), 200),
                        (nameof(RectangleWidget.Height), 100)
                    )
                )
            ),
        ];
        foreach (var widg in predefinedWidgetDetailsList)
        {
            _drawing.AddWidget(widg);
        }

        _drawing.PrintDrawing();
    }
}
