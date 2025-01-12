using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Abstract;

namespace Spreadex.Drawing.Models.Validators.Concrete;

internal class SquareWidgetValidator: BaseWidgetValidator<SquareWidget>
{
    public SquareWidgetValidator()
    {
        AddIsPositiveRule(x => x.Width, nameof(SquareWidget.Width));
    }
}