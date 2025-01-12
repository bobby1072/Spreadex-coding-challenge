using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Abstract;

namespace Spreadex.Drawing.Models.Validators.Concrete;

internal class TextboxWidgetValidator: BaseWidgetValidator<TextboxWidget>
{
    private readonly IValidator<RectangleWidget> _rectangleValidator;
    public TextboxWidgetValidator(IValidator<RectangleWidget> rectangleValidator)
    {
        _rectangleValidator = rectangleValidator;
        
        RuleFor(x => x.BoundingRectangle).SetValidator(_rectangleValidator);
    }
}