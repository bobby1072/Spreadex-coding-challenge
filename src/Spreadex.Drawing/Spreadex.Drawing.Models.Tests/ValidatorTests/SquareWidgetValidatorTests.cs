using System.Drawing;
using AutoFixture;
using FluentAssertions;
using FluentValidation;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Concrete;

namespace Spreadex.Drawing.Models.Tests.ValidatorTests;

public class SquareWidgetValidatorTests: ValidatorTestBase<SquareWidget>
{
    protected override IValidator<SquareWidget> Validator { get; init; }

    public SquareWidgetValidatorTests()
    {
        Validator = new SquareWidgetValidator();
    }

    [Theory]
    [ClassData(typeof(SquareWidgetValidatorTests_ClassData))]
    public void SquareWidgetValidator_ShouldValidateCorrectly(SquareWidget squareWidget, bool expectedResult) => RunTest(squareWidget, expectedResult);
    private class SquareWidgetValidatorTests_ClassData: TheoryData<SquareWidget, bool>
    {
        public SquareWidgetValidatorTests_ClassData()
        {
            Add(
                Fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, 100)
                    .Create(), 
                true
            );
            
            Add(
                Fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, -100)
                    .Create(), 
                false
            );
            
            Add(
                Fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, 1)
                    .Create(), 
                true
            );
            
            Add(
                Fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, 0)
                    .Create(), 
                true
            );
            
            Add(
                Fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, -1)
                    .Create(), 
                false
            );
        }
    }
    
}