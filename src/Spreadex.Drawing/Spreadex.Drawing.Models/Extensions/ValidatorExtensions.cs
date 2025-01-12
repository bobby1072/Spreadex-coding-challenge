using FluentValidation;
using Spreadex.Drawing.Models.Abstract;
using System.Linq.Expressions;

namespace Spreadex.Drawing.Models.Extensions;

internal static class WidgetValidatorExtensions
{
    public static void AddIsPositiveRule<T>(
        this AbstractValidator<T> validator,
        Expression<Func<T, int>> widgetPropertyExpression,
        string propName
    )
        where T : IWidget
    {
        validator
            .RuleFor(widgetPropertyExpression)
            .GreaterThanOrEqualTo(0)
            .WithMessage($"{propName} must be positive");
    }
}
