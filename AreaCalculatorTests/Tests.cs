namespace AreaCalculatorTests;

using ShapesLib;

public class Tests
{
    private static bool AreDoublesEqual(double first, double second)
        => Math.Abs(first - second) < 0.001;


    public static IEnumerable<TestCaseData> CorrectDataForAreaCalculationsOfCircles()
    {
        yield return new TestCaseData(new Circle(1), Math.PI);
        yield return new TestCaseData(new Circle(0), 0);
    }


    public static IEnumerable<TestCaseData> CorrectDataForAreaCalculationsOfTriangles()
    {
        yield return new TestCaseData(new Triangle(1, 2, 2), 0.968);
        yield return new TestCaseData(new Triangle(3, 4, 5), 6);
    }


    [TestCaseSource(nameof(CorrectDataForAreaCalculationsOfCircles))]
    [TestCaseSource(nameof(CorrectDataForAreaCalculationsOfTriangles))]
    public void CalculateAreaWithCorrectData(IShape shape, double expected)
        => Assert.That(AreDoublesEqual(shape.CalculateArea(), expected), Is.True);

    [Test]
    public void NegativeRadiusTest()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }

    [Test]
    public void NegativeOrZeroTriangleSideTest()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(0, 1, 1));
        Assert.Throws<ArgumentException>(() => new Triangle(-1, 1, 1));
    }

    [Test]
    public void SumLessTriangleTest()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 10));
    }

    [Test]
    public void IsRectangularTriangleTest()
    {
        Assert.That(new Triangle(3, 4, 5).IsRectangular(), Is.True);
    }
}