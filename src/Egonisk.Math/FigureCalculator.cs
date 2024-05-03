using Egonisk.Math.Abstractions;

namespace Egonisk.Math;

public static class FigureCalculator
{
    public static double CalculateSumArea(IEnumerable<IFigure> figures) => figures.Sum(figure => figure.GetArea());

    public static double CalculateArea(IFigure figure) => figure.GetArea();
}