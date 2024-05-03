using Egonisk.Math.Abstractions;

namespace Egonisk.Math.Figures;

public class Circle : IFigure
{
    private double _radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius
    {
        get => _radius;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Radius should be a positive number",
                    nameof(value));
            }
            _radius = value;
        }
    }

    public double GetArea()
    {
        return System.Math.PI * Radius * Radius;
    }
}