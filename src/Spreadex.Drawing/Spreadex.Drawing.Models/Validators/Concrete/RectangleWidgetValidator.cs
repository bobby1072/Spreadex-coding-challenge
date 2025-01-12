using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Abstract;

namespace Spreadex.Drawing.Models.Validators.Concrete;

internal class RectangleWidgetValidator: BaseWidgetValidator<RectangleWidget>
{
    public RectangleWidgetValidator()
    {
        AddIsPositiveRule(x => x.Height, nameof(RectangleWidget.Height));
        AddIsPositiveRule(x => x.Width, nameof(RectangleWidget.Width));
    }
}