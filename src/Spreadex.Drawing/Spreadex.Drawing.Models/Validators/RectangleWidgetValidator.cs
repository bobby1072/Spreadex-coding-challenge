using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Extensions;

namespace Spreadex.Drawing.Models.Validators;

internal class RectangleWidgetValidator : AbstractValidator<RectangleWidget>
{
    public RectangleWidgetValidator()
    {
        this.AddIsPositiveRule(x => x.Height, nameof(RectangleWidget.Height));
        this.AddIsPositiveRule(x => x.Width, nameof(RectangleWidget.Width));
    }
}
