﻿using Spreadex.Drawing.App.Abstract;
using Spreadex.Drawing.App.Extensions;
using Spreadex.Drawing.App.Services.Abstract;
using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.App.Concrete;

public class App: IApp
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
            _widgetFactory.CreateRectangle(10, 10, 30, 40),
            _widgetFactory.CreateSquare(15, 30, 35),
            _widgetFactory.CreateEllipse(100, 150, 300, 200),
            _widgetFactory.CreateCircle(1, 1, 300),
            _widgetFactory.CreateTextbox(5,5, "sample text", (RectangleWidget)_widgetFactory.CreateRectangle(5,5, 200, 100))
        ];
        var widgetDetails = predefinedWidgetDetailsList.ToWidgetDetailsList().ToArray();
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