using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Abstract;

namespace Spreadex.Drawing.Models.Validators.Concrete;

internal class EllipseWidgetValidator: BaseWidgetValidator<EllipseWidget>
{
    public EllipseWidgetValidator()
    {
        AddIsPositiveRule(x => x.HorizontalDiameter, nameof(EllipseWidget.HorizontalDiameter));
        AddIsPositiveRule(x => x.VerticalDiameter, nameof(EllipseWidget.VerticalDiameter));
    }
}