using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Spreadex.Drawing.App.Services.Abstract;
using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.App.Services.Concrete;

public class WidgetFactory: IWidgetFactory
{
    private readonly IServiceProvider _serviceProvider;

    public WidgetFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T CreateWidget<T>(PageLocation location, params (string Key, object Value)[] propertyArgs) where T : class, IWidget
    {
        var widgetType = typeof(T);
        var widget = Activator.CreateInstance(widgetType) as T;
        if (widget is null)
        {
            throw new InvalidOperationException($"Could not create an instance of type {widgetType.Name}");
        }

        foreach (var property in propertyArgs)
        {
            var propertyInfo = widgetType.GetProperty(property.Key, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo is null)
            {
                throw new ArgumentException($"Property {property.Key} does not exist on type {widgetType.Name}");
            }

            if (!propertyInfo.CanWrite)
            {
                throw new ArgumentException($"Property {property.Key} on type {widgetType.Name} is read-only");
            }

            if (property.Value is not null && !propertyInfo.PropertyType.IsInstanceOfType(property.Value))
            {
                throw new ArgumentException($"Invalid type for property {property.Key}. Expected {propertyInfo.PropertyType.Name} but got {property.Value.GetType().Name}");
            }

            propertyInfo.SetValue(widget, property.Value);
        }
        var locationPropertyInfo = widgetType.GetProperty(nameof(IWidget.Location), BindingFlags.Public | BindingFlags.Instance);
        if (locationPropertyInfo is null)
        {
            throw new ArgumentException($"Property {nameof(IWidget.Location)} does not exist on type {widgetType.Name}");
        }
        locationPropertyInfo.SetValue(widget, location);
        var validator = _serviceProvider.GetService<IValidator<T>>();
        validator?.ValidateAndThrow(widget);

        return widget;
    }
}
