using Egonisk.Math;
using Egonisk.Math.Abstractions;
using Egonisk.Math.Figures;

namespace Egonisk.MathUnitTests;

public class FigureCalculatorTest : BaseTest
{
    [Fact]
    public void CalculateArea_ShouldReturnCorrectValue()
    {
        var circle = new Circle(5);
        var triangle = new Triangle(3, 6, 7);
        var expectedCircleArea = 78.54;
        var expectedTriangleArea = 8.94;

        var actualCircleArea = System.Math.Round(FigureCalculator.CalculateArea(circle), 
            RoundToFractionalDigits);
        var actualTriangleArea = System.Math.Round(FigureCalculator.CalculateArea(triangle), 
            RoundToFractionalDigits);
        
        Assert.Equal(expectedCircleArea, actualCircleArea);
        Assert.Equal(expectedTriangleArea, actualTriangleArea);
    }
    
    [Fact]
    public void CalculateSumArea_ShouldReturnCorrectValue()
    {
        var circle = new Circle(5);
        var triangle = new Triangle(3, 6, 7);
        var figures = new List<IFigure>() { circle, triangle };
        var expectedCircleArea = 78.54;
        var expectedTriangleArea = 8.94;
        var expectedSumArea = expectedCircleArea + expectedTriangleArea;

        var actualSumArea = System.Math.Round(FigureCalculator.CalculateSumArea(figures), 
            RoundToFractionalDigits);
        
        Assert.Equal(expectedSumArea, actualSumArea);
    }
}