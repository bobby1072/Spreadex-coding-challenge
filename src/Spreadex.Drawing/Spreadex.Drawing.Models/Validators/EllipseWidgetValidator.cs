using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Extensions;

namespace Spreadex.Drawing.Models.Validators;

internal class EllipseWidgetValidator : AbstractValidator<EllipseWidget>
{
    public EllipseWidgetValidator()
    {
        this.AddIsPositiveRule(x => x.HorizontalDiameter, nameof(EllipseWidget.HorizontalDiameter));
        this.AddIsPositiveRule(x => x.VerticalDiameter, nameof(EllipseWidget.VerticalDiameter));
    }
}
