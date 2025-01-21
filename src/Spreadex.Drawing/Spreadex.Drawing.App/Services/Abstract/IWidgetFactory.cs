using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.App.Services.Abstract;

public interface IWidgetFactory
{
    T CreateWidget<T>(PageLocation location, params (string Key, object Value)[] propertyArgs)
        where T : class, IWidget;
}
