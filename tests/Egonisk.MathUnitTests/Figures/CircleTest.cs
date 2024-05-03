using Egonisk.Math.Figures;

namespace Egonisk.MathUnitTests.Figures;

public class CircleTest : BaseTest
{
    [Fact]
    public void GetArea_ShouldReturnCorrectValue()
    {
        var circle = new Circle(5);
        var expectedArea = 78.54;

        var actualArea = System.Math.Round(circle.GetArea(), RoundToFractionalDigits);
        
        Assert.Equal(expectedArea, actualArea);
    }
}