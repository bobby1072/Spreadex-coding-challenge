using AutoFixture;
using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Concrete;

namespace Spreadex.Drawing.Models.Tests.ValidatorTests;

public class TextBoxWidgetValidatorTests: ValidatorTestBase<TextboxWidget>
{
    protected override IValidator<TextboxWidget> Validator { get; init; }

    public TextBoxWidgetValidatorTests()
    {
        Validator = new TextboxWidgetValidator(new RectangleWidgetValidator());
    }
    
    [Theory]
    [ClassData(typeof(TextboxWidgetValidatorTests_ClassData))]
    public void TextBoxWidgetValidator_ShouldValidateCorrectly(TextboxWidget rectangleWidget, bool expectedResult) => RunTest(rectangleWidget, expectedResult);
    private class TextboxWidgetValidatorTests_ClassData: TheoryData<TextboxWidget, bool>
    {
        public TextboxWidgetValidatorTests_ClassData()
        {
            Add(
                Fixture
                    .Build<TextboxWidget>()
                    .With(x => x.BoundingRectangle, 
                        Fixture
                            .Build<RectangleWidget>()
                            .With(x => x.Width, 100)
                            .With(x => x.Height, 100)
                            .Create()
                        )
                    .Create(),
                true
            );
            Add(
                Fixture
                    .Build<TextboxWidget>()
                    .With(x => x.BoundingRectangle, 
                        Fixture
                            .Build<RectangleWidget>()
                            .With(x => x.Width, -100)
                            .With(x => x.Height, -100)
                            .Create()
                        )
                    .Create(),
                false
            );            
            Add(
                Fixture
                    .Build<TextboxWidget>()
                    .With(x => x.BoundingRectangle, 
                        Fixture
                            .Build<RectangleWidget>()
                            .With(x => x.Width, 1)
                            .With(x => x.Height, 1)
                            .Create()
                        )
                    .Create(),
                true
            );            
            Add(
                Fixture
                    .Build<TextboxWidget>()
                    .With(x => x.BoundingRectangle, 
                        Fixture
                            .Build<RectangleWidget>()
                            .With(x => x.Width, 0)
                            .With(x => x.Height, 0)
                            .Create()
                        )
                    .Create(),
                true
            );            
            Add(
                Fixture
                    .Build<TextboxWidget>()
                    .With(x => x.BoundingRectangle, 
                        Fixture
                            .Build<RectangleWidget>()
                            .With(x => x.Width, -1)
                            .With(x => x.Height, -1)
                            .Create()
                        )
                    .Create(),
                false
            );
            Add(
                Fixture
                    .Build<TextboxWidget>()
                    .With(x => x.BoundingRectangle, 
                        Fixture
                            .Build<RectangleWidget>()
                            .With(x => x.Width, -1)
                            .With(x => x.Height, 100)
                            .Create()
                    )
                    .Create(),
                false
            );            Add(
                Fixture
                    .Build<TextboxWidget>()
                    .With(x => x.BoundingRectangle, 
                        Fixture
                            .Build<RectangleWidget>()
                            .With(x => x.Width, 6)
                            .With(x => x.Height, -1)
                            .Create()
                    )
                    .Create(),
                false
            );
        }
    }
}