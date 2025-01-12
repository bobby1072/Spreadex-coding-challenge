using AutoFixture;
using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Concrete;

namespace Spreadex.Drawing.Models.Tests.ValidatorTests;

public class CircleWidgetValidatorTests :ValidatorTestBase<CircleWidget>
{
    protected override IValidator<CircleWidget> Validator { get; init; }

    public CircleWidgetValidatorTests()
    {
        Validator = new CircleWidgetValidator();
    }
    
    [Theory]
    [ClassData(typeof(CircleWidgetValidatorTests_ClassData))]
    public void CircleWidgetValidator_ShouldValidateCorrectly(CircleWidget rectangleWidget, bool expectedResult) => RunTest(rectangleWidget, expectedResult);
    private class CircleWidgetValidatorTests_ClassData: TheoryData<CircleWidget, bool>
    {
        public CircleWidgetValidatorTests_ClassData()
        {
            Add(
                Fixture
                    .Build<CircleWidget>()
                    .With(x => x.Diameter, 100)
                    .Create(),
                true
            );
            Add(
                Fixture
                    .Build<CircleWidget>()
                    .With(x => x.Diameter, -100)
                    .Create(),
                false
            );            
            Add(
                Fixture
                    .Build<CircleWidget>()
                    .With(x => x.Diameter, 1)
                    .Create(),
                true
            );            
            Add(
                Fixture
                    .Build<CircleWidget>()
                    .With(x => x.Diameter, 0)
                    .Create(),
                true
            );            
            Add(
                Fixture
                    .Build<CircleWidget>()
                    .With(x => x.Diameter, -1)
                    .Create(),
                false
            );
        }
    }
}