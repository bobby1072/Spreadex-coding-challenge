using Microsoft.Extensions.DependencyInjection;
using Spreadex.Drawing.App.Abstract;
using Spreadex.Drawing.App.Services.Abstract;
using Spreadex.Drawing.App.Services.Concrete;
using Spreadex.Drawing.Models.Abstract;
using Spreadex.Drawing.Models.Extensions;

namespace Spreadex.Drawing.App.Extensions;

public static class SpreadexDrawingServiceCollectionExtensions
{
    public static IServiceCollection AddSpreadexDrawing(this IServiceCollection services)
    {
        services
            .AddTransient<IDrawing, Models.Concrete.Drawing>()
            .AddTransient<IWidgetFactory, WidgetFactory>()
            .AddTransient<IApp, Concrete.App>()
            .AddWidgetValidators();
        
        return services;
    }     
}