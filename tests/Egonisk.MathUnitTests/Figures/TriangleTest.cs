using Egonisk.Math.Figures;

namespace Egonisk.MathUnitTests.Figures;

public class TriangleTest : BaseTest
{
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(4, 5, 3)]
    [InlineData(5, 4, 3)]
    public void IsRight_ShouldReturnTrue(double aSideLength, double bSideLength, double cSideLength)
    {
        var rightTriangle = new Triangle(aSideLength, bSideLength, cSideLength);
        var expectedResult = true;
        
        var actualResult = rightTriangle.IsRight();
        
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Fact]
    public void IsRight_ShouldReturnFalse()
    {
        var triangle = new Triangle(7, 6, 3);
        var expectedResult = false;
        
        var actualResult = triangle.IsRight();
        
        Assert.Equal(expectedResult, actualResult);
    }    
    
    [Fact]
    public void Constructor_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var invalidTriangle = new Triangle(7, 6, 1);
        });
    }
    
    [Fact]
    public void GetArea_ShouldReturnCorrectValue()
    {
        var triangle = new Triangle(8, 11, 13);
        var expectedArea = 43.82;
        
        var actualArea = System.Math.Round(triangle.GetArea(), RoundToFractionalDigits);
        
        Assert.Equal(expectedArea, actualArea);
    }
}