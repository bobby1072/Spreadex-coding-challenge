using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Abstract;

namespace Spreadex.Drawing.Models.Validators.Concrete;

internal class CircleWidgetValidator: BaseWidgetValidator<CircleWidget>
{
    public CircleWidgetValidator()
    {
        AddIsPositiveRule(x => x.Diameter, nameof(CircleWidget.Diameter));
    }
}