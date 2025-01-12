using FluentValidation;
using Spreadex.Drawing.Models.Concrete;

namespace Spreadex.Drawing.Models.Validators;

internal class TextboxWidgetValidator : AbstractValidator<TextboxWidget>
{
    private readonly IValidator<RectangleWidget> _rectangleValidator;

    public TextboxWidgetValidator(IValidator<RectangleWidget> rectangleValidator)
    {
        _rectangleValidator = rectangleValidator;

        RuleFor(x => x.BoundingRectangle).SetValidator(_rectangleValidator);
    }
}
