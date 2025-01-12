using System.Drawing;
using AutoFixture;
using FluentAssertions;
using Spreadex.Drawing.Models.Concrete;
using Spreadex.Drawing.Models.Validators.Concrete;

namespace Spreadex.Drawing.Models.Tests.ValidatorTests;

public class SquareWidgetValidatorTests
{
    private static readonly Fixture _fixture = new();
    private readonly SquareWidgetValidator _squareWidgetValidator;

    public SquareWidgetValidatorTests()
    {
        _squareWidgetValidator = new SquareWidgetValidator();
    }

    [Theory]
    [ClassData(typeof(SquareWidgetValidatorTests_ClassData))]
    public void TestSquareWidgetValidator(SquareWidget squareWidget, bool expectedResult)
    {
        _squareWidgetValidator.Validate(squareWidget).IsValid.Should().Be(expectedResult);
    }
    public class SquareWidgetValidatorTests_ClassData: TheoryData<SquareWidget, bool>
    {
        public SquareWidgetValidatorTests_ClassData()
        {
            Add(
                _fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, 100)
                    .Create(), 
                true
            );
            
            Add(
                _fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, -100)
                    .Create(), 
                false
            );
            
            Add(
                _fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, 1)
                    .Create(), 
                true
            );
            
            Add(
                _fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, 0)
                    .Create(), 
                true
            );
            
            Add(
                _fixture
                    .Build<SquareWidget>()
                    .With(x => x.Width, -1)
                    .Create(), 
                false
            );
        }
    }
    
}