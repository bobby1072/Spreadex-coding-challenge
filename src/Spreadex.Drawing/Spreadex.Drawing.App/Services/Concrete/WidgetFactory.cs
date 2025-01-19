using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Spreadex.Drawing.App.Services.Abstract;
using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.App.Services.Concrete;

public class WidgetFactoryV2
{
    private readonly IServiceProvider _serviceProvider;

    public WidgetFactoryV2(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T CreateWidget<T>(IDictionary<string, object> propertyArgs) where T : class, IWidget
    {
        var widgetType = typeof(T);
        var widget = Activator.CreateInstance(widgetType) as T;
        if (widget == null)
        {
            throw new InvalidOperationException($"Could not create an instance of type {widgetType.Name}.");
        }

        foreach (var property in propertyArgs)
        {
            var propertyInfo = widgetType.GetProperty(property.Key, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property {property.Key} does not exist on type {widgetType.Name}.");
            }

            if (!propertyInfo.CanWrite)
            {
                throw new ArgumentException($"Property {property.Key} on type {widgetType.Name} is read-only.");
            }

            if (property.Value != null && !propertyInfo.PropertyType.IsInstanceOfType(property.Value))
            {
                throw new ArgumentException($"Invalid type for property {property.Key}. Expected {propertyInfo.PropertyType.Name} but got {property.Value.GetType().Name}.");
            }

            propertyInfo.SetValue(widget, property.Value);
        }

        var validator = _serviceProvider.GetService<IValidator<T>>();
        validator?.ValidateAndThrow(widget);

        return widget;
    }
}
public class WidgetFactory : IWidgetFactory
{
    private readonly IServiceProvider _serviceProvider;

    public WidgetFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IWidget CreateRectangle(int x, int y, int width, int height)
    {
        var rect = new RectangleWidget
        {
            Height = height,
            Location = new PageLocation { X = x, Y = y },
            Width = width,
        };

        _serviceProvider.GetService<IValidator<RectangleWidget>>()?.ValidateAndThrow(rect);

        return rect;
    }

    public IWidget CreateCircle(int x, int y, int diameter)
    {
        var circle = new CircleWidget
        {
            Diameter = diameter,
            Location = new PageLocation { X = x, Y = y },
        };

        _serviceProvider.GetService<IValidator<CircleWidget>>()?.ValidateAndThrow(circle);

        return circle;
    }

    public IWidget CreateEllipse(int x, int y, int horizontalDiameter, int verticalDiameter)
    {
        var ellipseWidget = new EllipseWidget
        {
            Location = new PageLocation { X = x, Y = y },
            HorizontalDiameter = horizontalDiameter,
            VerticalDiameter = verticalDiameter,
        };

        _serviceProvider.GetService<IValidator<EllipseWidget>>()?.ValidateAndThrow(ellipseWidget);

        return ellipseWidget;
    }

    public IWidget CreateSquare(int x, int y, int width)
    {
        var square = new SquareWidget
        {
            Location = new PageLocation { X = x, Y = y },
            Width = width,
        };

        _serviceProvider.GetService<IValidator<SquareWidget>>()?.ValidateAndThrow(square);

        return square;
    }

    public IWidget CreateTextbox(int x, int y, string text, RectangleWidget rectangle)
    {
        var textBox = new TextboxWidget
        {
            Location = new PageLocation { X = x, Y = y },
            Text = text,
            BoundingRectangle = rectangle,
        };

        _serviceProvider.GetService<IValidator<TextboxWidget>>()?.ValidateAndThrow(textBox);

        return textBox;
    }
}
