using AutoFixture;
using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Concrete;

namespace Spreadex.Drawing.Models.Tests.ValidatorTests;

public class RectangleWidgetValidatorTests: ValidatorTestBase<RectangleWidget>
{
    protected override IValidator<RectangleWidget> Validator { get; init; }

    public RectangleWidgetValidatorTests()
    {
        Validator = new RectangleWidgetValidator();
    }
    [Theory]
    [ClassData(typeof(RectangleWidgetValidatorTests_ClassData))]
    public void RectangleWidgetValidator_ShouldValidateCorrectly(RectangleWidget rectangleWidget, bool expectedResult) => RunTest(rectangleWidget, expectedResult);
    private class RectangleWidgetValidatorTests_ClassData: TheoryData<RectangleWidget, bool>
    {
        public RectangleWidgetValidatorTests_ClassData()
        {
            Add(
                Fixture
                    .Build<RectangleWidget>()
                    .With(x => x.Width, 100)
                    .With(x => x.Height, 100)
                    .Create(),
                true
            );
            Add(
                Fixture
                    .Build<RectangleWidget>()
                    .With(x => x.Width, -100)
                    .With(x => x.Height, -100)
                    .Create(),
                false
            );            
            Add(
                Fixture
                    .Build<RectangleWidget>()
                    .With(x => x.Width, 1)
                    .With(x => x.Height, 1)
                    .Create(),
                true
            );            
            Add(
                Fixture
                    .Build<RectangleWidget>()
                    .With(x => x.Width, 0)
                    .With(x => x.Height, 0)
                    .Create(),
                true
            );            
            Add(
                Fixture
                    .Build<RectangleWidget>()
                    .With(x => x.Width, -1)
                    .With(x => x.Height, -1)
                    .Create(),
                false
            );
            Add(
                Fixture
                    .Build<RectangleWidget>()
                    .With(x => x.Width, -1)
                    .With(x => x.Height, 100)
                    .Create(),
                false
            );
            Add(
                Fixture
                    .Build<RectangleWidget>()
                    .With(x => x.Width, 6)
                    .With(x => x.Height, -1)
                    .Create(),
                false
            );
        }
    }
}