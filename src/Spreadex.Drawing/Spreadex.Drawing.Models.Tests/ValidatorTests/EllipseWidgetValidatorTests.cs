using AutoFixture;
using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Concrete;

namespace Spreadex.Drawing.Models.Tests.ValidatorTests;

public class EllipseWidgetValidatorTests: ValidatorTestBase<EllipseWidget>
{
    protected override IValidator<EllipseWidget> Validator { get; init; }

    public EllipseWidgetValidatorTests()
    {
        Validator = new EllipseWidgetValidator();
    }
    
    [Theory]
    [ClassData(typeof(EllipseWidgetValidatorTests_ClassData))]
    public void EllipseWidgetValidator_ShouldValidateCorrectly(EllipseWidget rectangleWidget, bool expectedResult) => RunTest(rectangleWidget, expectedResult);
    private class EllipseWidgetValidatorTests_ClassData: TheoryData<EllipseWidget, bool>
    {
        public EllipseWidgetValidatorTests_ClassData()
        {
            Add(
                Fixture
                    .Build<EllipseWidget>()
                    .With(x => x.HorizontalDiameter, 100)
                    .With(x => x.VerticalDiameter, 100)
                    .Create(),
                true
            );
            Add(
                Fixture
                    .Build<EllipseWidget>()
                    .With(x => x.HorizontalDiameter, -100)
                    .With(x => x.VerticalDiameter, -100)
                    .Create(),
                false
            );            
            Add(
                Fixture
                    .Build<EllipseWidget>()
                    .With(x => x.HorizontalDiameter, 1)
                    .With(x => x.VerticalDiameter, 1)
                    .Create(),
                true
            );            
            Add(
                Fixture
                    .Build<EllipseWidget>()
                    .With(x => x.HorizontalDiameter, 0)
                    .With(x => x.VerticalDiameter, 0)
                    .Create(),
                true
            );            
            Add(
                Fixture
                    .Build<EllipseWidget>()
                    .With(x => x.HorizontalDiameter, -1)
                    .With(x => x.VerticalDiameter, -1)
                    .Create(),
                false
            );
            Add(
                Fixture
                    .Build<EllipseWidget>()
                    .With(x => x.HorizontalDiameter, -1)
                    .With(x => x.VerticalDiameter, 100)
                    .Create(),
                false
            );
            Add(
                Fixture
                    .Build<EllipseWidget>()
                    .With(x => x.HorizontalDiameter, 6)
                    .With(x => x.VerticalDiameter, -1)
                    .Create(),
                false
            );
        }
    }
}