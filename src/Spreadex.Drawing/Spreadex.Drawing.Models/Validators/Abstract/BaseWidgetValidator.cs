using System.Linq.Expressions;
using FluentValidation;
using Spreadex.Drawing.Models.Abstract;

namespace Spreadex.Drawing.Models.Validators.Abstract;

internal class BaseWidgetValidator<T>: AbstractValidator<T> where T: IWidget
{
    protected void AddIsPositiveRule(Expression<Func<T, int>> widgetPropertyExpression,
        string propName)
    {
        RuleFor(widgetPropertyExpression).GreaterThanOrEqualTo(0).WithMessage(propName + " must be positive");
    }
}