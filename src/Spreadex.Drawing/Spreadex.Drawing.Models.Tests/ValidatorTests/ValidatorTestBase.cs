using AutoFixture;
using FluentAssertions;
using FluentValidation;

namespace Spreadex.Drawing.Models.Tests.ValidatorTests;

public abstract class ValidatorTestBase<T>
{
    protected static readonly Fixture Fixture = new();
    protected abstract IValidator<T> Validator { get; init; }
    protected void RunTest(T objToValidate, bool expectedResult)
    {
        Validator.Validate(objToValidate).IsValid.Should().Be(expectedResult);
    }
}