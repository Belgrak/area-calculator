namespace ShapesLib;

public class Circle : IShape
{
    public int Radius { get; }

    public Circle(int radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Argument can't be less than 0");
        }

        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}