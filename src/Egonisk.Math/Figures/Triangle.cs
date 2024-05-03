using Egonisk.Math.Abstractions;

namespace Egonisk.Math.Figures;

public class Triangle : IFigure
{
    private readonly double _aSideLength;
    private readonly double _bSideLength;
    private readonly double _cSideLength;

    public Triangle(double aSideLength, double bSideLength, double cSideLength)
    {
        if (!IsValid(aSideLength, bSideLength, cSideLength))
        {
            throw new ArgumentException("Sides length must form a valid triangle.");
        }
        
        ASideLength = aSideLength;
        BSideLength = bSideLength;
        CSideLength = cSideLength;
    }

    public double ASideLength
    {
        get => _aSideLength;
        init
        {
            ValidateSideLength(value);
            _aSideLength = value;
        }
    }

    public double BSideLength
    {
        get => _bSideLength;
        init
        {
            ValidateSideLength(value);
            _bSideLength = value;
        }
    }

    public double CSideLength
    {
        get => _cSideLength;
        init
        {
            ValidateSideLength(value);
            _cSideLength = value;
        }
    }

    public double GetArea()
    {
        // Heron's formula
        var semiPerimeter = (ASideLength + BSideLength + CSideLength) / 2;
        var area = System.Math.Sqrt(semiPerimeter *
                                    (semiPerimeter - ASideLength) *
                                    (semiPerimeter - BSideLength) *
                                    (semiPerimeter - CSideLength));
        return area;
    }

    private void ValidateSideLength(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Side length should be a positive number",
                nameof(value));
        }
    }
    
    private bool IsValid(double aSideLength, double bSideLength, double cSideLength)
    {
        // Triangle inequality theorem
        return aSideLength + bSideLength > cSideLength && 
               bSideLength + cSideLength > aSideLength && 
               aSideLength + cSideLength > bSideLength;
    }

    public bool IsRight()
    {
        // Pythagorean theorem
        var sumOfSquaresOfSidesAAndB = ASideLength * ASideLength + BSideLength * BSideLength;
        var sumOfSquaresOfSidesAAndC = ASideLength * ASideLength + CSideLength * CSideLength;
        var sumOfSquaresOfSidesBAndC = BSideLength * BSideLength + CSideLength * CSideLength;
        var squareOfCSide = CSideLength * CSideLength;
        var squareOfBSide = BSideLength * BSideLength;
        var squareOfASide = ASideLength * ASideLength;
        
        // Comparing floating-point numbers to a certain precision
        const double tolerance = 0.000000001;
        return System.Math.Abs(sumOfSquaresOfSidesAAndB - squareOfCSide) < tolerance ||
               System.Math.Abs(sumOfSquaresOfSidesAAndC - squareOfBSide) < tolerance ||
               System.Math.Abs(sumOfSquaresOfSidesBAndC - squareOfASide) < tolerance;

    }
}