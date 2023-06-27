using FluentAssertions;
using MindboxSquare;
using MindboxSquare.Shapes;

namespace UnitTests;

public class TriangleTests
{
    /// <summary>
    /// Метод <see cref="Triangle.WithSides"/> должен бросать исключение <see cref="ArgumentException"/>,
    /// если хотя бы одна из сторон меньше нуля (или равна нулю).
    /// </summary>
    [Fact]
    public void TriangleWithSides_ThrowsAnException_WhenAnySideNegativeOrZero()
    {
        var firstSideIsNegativeCreation = () => ShapeFactory.CreateShape<Triangle>().WithSides(int.MinValue, 1, 1);
        var secondSideIsNegativeCreation = () => ShapeFactory.CreateShape<Triangle>().WithSides(1, int.MinValue, 1);
        var thirdSideIsNegativeCreation = () => ShapeFactory.CreateShape<Triangle>().WithSides(1, 1, int.MinValue);
        
        var firstSideIsZeroCreation = () => ShapeFactory.CreateShape<Triangle>().WithSides(0, 1, 1);
        var secondSideIsZeroCreation = () => ShapeFactory.CreateShape<Triangle>().WithSides(1, 0, 1);
        var thirdSideIsZeroCreation = () => ShapeFactory.CreateShape<Triangle>().WithSides(1, 1, 0);

        firstSideIsNegativeCreation.Should().Throw<ArgumentException>("Первая сторона треугольника не может быть отрицательной");
        secondSideIsNegativeCreation.Should().Throw<ArgumentException>("Вторая сторона треугольника не может быть отрицательной");
        thirdSideIsNegativeCreation.Should().Throw<ArgumentException>("Третья сторона треугольника не может быть отрицательной");
        
        firstSideIsZeroCreation.Should().Throw<ArgumentException>("Первая сторона треугольника не может быть равной нулю");
        secondSideIsZeroCreation.Should().Throw<ArgumentException>("Вторая сторона треугольника не может быть равной нулю");
        thirdSideIsZeroCreation.Should().Throw<ArgumentException>("Третья сторона треугольника не может быть равной нулю");
    }
    
    /// <summary>
    /// Метод <see cref="Triangle.WithSides"/> должен бросать исключение <see cref="ArgumentException"/>,
    /// если треугольник с заданными сторонами не может существовать.
    /// </summary>
    [Fact]
    public void TriangleWithSides_ThrowsAnException_WhenTriangleWithSidesCantBeExist()
    {
        var act = () => ShapeFactory.CreateShape<Triangle>().WithSides(4, 1, 1);

        act.Should().Throw<ArgumentException>("Треугольник со сторонами 4, 1, 1 не может существовать.");
    }
    
    /// <summary>
    /// Метод <see cref="Triangle.GetSquare"/> должен бросать исключение, если фигура не проинициализирована.
    /// </summary>
    [Fact]
    public void CircleGetSquare_ThrowsAnException_WhenFigureNotInitialized()
    {
        var act = () => ShapeFactory.CreateShape<Triangle>().GetSquare();

        act.Should().Throw<ApplicationException>("Фигура не проинициализирована");
    }
    
    /// <summary>
    /// Метод <see cref="Triangle.IsRightAngled"/> должен возвращать False, если треугольник не прямоугольный.
    /// </summary>
    [Fact]
    public void IsRightAngled_GivesFalse_WhenTriangleIsNotRightAngled()
    {
        ShapeFactory.CreateTriangle(3, 3, 5).IsRightAngled().Should().BeFalse("Треугольник не прямоугольный");
    }

    /// <summary>
    /// Метод <see cref="Triangle.IsRightAngled"/> должен возвращать True, если треугольник прямоугольный.
    /// </summary>
    [Fact]
    public void IsRightAngled_GivesTrue_WhenTriangleIsRightAngled()
    {
        ShapeFactory.CreateTriangle(3, 4, 5).IsRightAngled().Should().BeTrue("Треугольник прямоугольный.");
    }
    
    /// <summary>
    /// Метод <see cref="Triangle.GetSquare"/> возвращает корректный результат, если объект треугольника проинициализирован правильно,
    /// а сам треугольник является прямоугольным.
    /// </summary>
    [Fact]
    public void RightAngledTriangleGetSquare_GivesCorrectResult()
    {
        ShapeFactory.CreateTriangle(3, 4, 5).GetSquare().Should().Be(6);
    }
    
    /// <summary>
    /// Метод <see cref="Triangle.GetSquare"/> возвращает корректный результат, если объект треугольника проинициализирован правильно,
    /// а сам треугольник является равносторонним.
    /// </summary>
    [Fact]
    public void EquilateralTriangleGetSquare_GivesCorrectResult()
    {
        ShapeFactory.CreateTriangle(2, 2, 2).GetSquare().Should().Be(1.7320508075688772);
    }

    /// <summary>
    /// Метод <see cref="Triangle.GetSquare"/> возвращает корректный результат, если объект треугольника проинициализирован правильно,
    /// а сам треугольник не является ни равносторонним, ни прямоугольным.
    /// </summary>
    [Fact]
    public void TriangleGetSquare_GivesCorrectResult()
    {
        ShapeFactory.CreateTriangle(3, 3, 5).GetSquare().Should().Be(4.14578098794425);
    }

    /// <summary>
    /// Метод <see cref="ShapeFactory.CreateShape{TShape}"/>, где TShape - <see cref="Triangle"/>
    /// должен возвращать корректный объет фигуры <see cref="Triangle"/>.
    /// </summary>
    [Fact]
    public void ShapeFactoryCreateShapeTriangle_GivesTriangle()
    {
        ShapeFactory.CreateShape<Triangle>().Should().BeOfType(typeof(Triangle));
    }
    
    /// <summary>
    /// Метод <see cref="ShapeFactory.CreateTriangle"/>
    /// должен возвращать корректный объет фигуры <see cref="Triangle"/>.
    /// </summary>
    [Fact]
    public void ShapeFactoryCreateTriangle_GivesTriangle()
    {
        ShapeFactory.CreateTriangle(1, 1, 1).Should().BeOfType(typeof(Triangle));
    }
}