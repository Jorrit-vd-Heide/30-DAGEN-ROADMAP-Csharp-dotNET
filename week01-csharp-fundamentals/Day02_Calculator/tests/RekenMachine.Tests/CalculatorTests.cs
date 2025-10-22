using Xunit;

namespace RekenMachine.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    public void Add_ReturnsSum(double a, double b, double expected)
    {
        Assert.Equal(expected, Calculator.Add(a, b));
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 5, -5)]
    public void Subtract_ReturnsDifference(double a, double b, double expected)
    {
        Assert.Equal(expected, Calculator.Subtract(a, b));
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-2, 3, -6)]
    public void Multiply_ReturnsProduct(double a, double b, double expected)
    {
        Assert.Equal(expected, Calculator.Multiply(a, b));
    }

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(-6, 3, -2)]
    public void Divide_ReturnsQuotient(double a, double b, double expected)
    {
        Assert.Equal(expected, Calculator.Divide(a, b));
    }

    [Fact]
    public void Divide_ByZero_Throws()
    {
        Assert.Throws<System.DivideByZeroException>(() => Calculator.Divide(1, 0));
    }
}
