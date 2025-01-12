using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Extensions;

namespace Spreadex.Drawing.Models.Validators;

internal class SquareWidgetValidator : AbstractValidator<SquareWidget>
{
    public SquareWidgetValidator()
    {
        this.AddIsPositiveRule(x => x.Width, nameof(SquareWidget.Width));
    }
}
