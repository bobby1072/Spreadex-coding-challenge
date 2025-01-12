using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Extensions;

namespace Spreadex.Drawing.Models.Validators;

internal class CircleWidgetValidator : AbstractValidator<CircleWidget>
{
    public CircleWidgetValidator()
    {
        this.AddIsPositiveRule(x => x.Diameter, nameof(CircleWidget.Diameter));
    }
}
