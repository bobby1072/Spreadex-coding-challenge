using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Concrete;

namespace Spreadex.Drawing.Models.Extensions;

public static class SpreadexDrawingModelsServiceCollectionExtensions
{
    public static IServiceCollection AddWidgetValidators(this IServiceCollection services)
    {
        services
            .AddSingleton<IValidator<CircleWidget>, CircleWidgetValidator>()
            .AddSingleton<IValidator<RectangleWidget>, RectangleWidgetValidator>()
            .AddSingleton<IValidator<EllipseWidget>, EllipseWidgetValidator>()
            .AddSingleton<IValidator<SquareWidget>, SquareWidgetValidator>()
            .AddSingleton<IValidator<TextboxWidget>, TextboxWidgetValidator>();
        
        return services;
    }
}