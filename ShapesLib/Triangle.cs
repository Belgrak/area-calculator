namespace ShapesLib;

public class Triangle : IShape
{
    public int FirstSide { get; }
    public int SecondSide { get; }
    public int ThirdSide { get; }
    private double? Area { get; set; }

    public Triangle(int firstSide, int secondSide, int thirdSide)
    {
        if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
        {
            throw new ArgumentException("All sides must be greater than 0");
        }

        if (!IsTriangle(firstSide, secondSide, thirdSide))
        {
            throw new ArgumentException("Sum of two sides is less than third ones");
        }

        (FirstSide, SecondSide, ThirdSide) = (firstSide, secondSide, thirdSide);
    }

    public double CalculateArea()
    {
        if (Area.HasValue)
        {
            return Area.Value;
        }

        var p = (FirstSide + SecondSide + ThirdSide) / 2.0;
        Area = Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));

        return Area.Value;
    }

    public bool IsRectangular()
        => FirstSide * FirstSide == SecondSide * SecondSide + ThirdSide * ThirdSide ||
           SecondSide * SecondSide == FirstSide * FirstSide + ThirdSide * ThirdSide ||
           ThirdSide * ThirdSide == SecondSide * SecondSide + FirstSide * FirstSide;

    private static bool IsTriangle(float firstSide, float secondSide, float thirdSide)
    {
        return firstSide + secondSide > thirdSide &&
               secondSide + thirdSide > firstSide &&
               thirdSide + firstSide > secondSide;
    }
}