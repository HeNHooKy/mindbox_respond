using FluentAssertions;
using MindboxSquare;
using MindboxSquare.Shapes;

namespace UnitTests;

public class CircleTests
{
    /// <summary>
    /// Метод <see cref="Circle.WithRadius"/> должен бросать исключение <see cref="ArgumentException"/>,
    /// если радиус меньше нуля (или равен нулю).
    /// </summary>
    [Fact]
    public void CircleWithRadius_ThrowsAnException_WhenNegativeOrZeroRadius()
    {
        var negativeRadiusCircleCreation = () => ShapeFactory.CreateShape<Circle>().WithRadius(-1);
        var zeroRadiusCircleCreation = () => ShapeFactory.CreateShape<Circle>().WithRadius(0);
        
        negativeRadiusCircleCreation.Should().Throw<ArgumentException>();
        zeroRadiusCircleCreation.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Метод <see cref="Circle.GetSquare"/> должен бросать исключение, если фигура не проинициализирована.
    /// </summary>
    [Fact]
    public void CircleGetSquare_ThrowsAnException_WhenFigureNotInitialized()
    {
        var act = () => ShapeFactory.CreateShape<Circle>().GetSquare();

        act.Should().Throw<ApplicationException>("Объект фигуры не проинициализирован.");
    }

    /// <summary>
    /// Метод <see cref="Circle.GetSquare"/> возвращает корректный результат, если объект проинициализирован правильно.
    /// </summary>
    [Fact]
    public void CircleGetSquare_GivesCorrectResult()
    {
        const double bottomCorrectAnswerBorder = 94.985;
        const double topCorrectAnswerBorder = 95.0455;
        
        ShapeFactory.CreateCircle(5.5).GetSquare().Should().BeInRange(bottomCorrectAnswerBorder, topCorrectAnswerBorder);
    }
    
    /// <summary>
    /// Метод <see cref="ShapeFactory.CreateShape{TShape}"/>, где TShape - <see cref="Circle"/>
    /// должен возвращать корректный объет фигуры <see cref="Circle"/>.
    /// </summary>
    [Fact]
    public void ShapeFactoryCreateShapeCircle_GivesCircle()
    {
        ShapeFactory.CreateShape<Circle>().Should().BeOfType(typeof(Circle));
    }
    
    /// <summary>
    /// Метод <see cref="ShapeFactory.CreateCircle"/>
    /// должен возвращать корректный объет фигуры <see cref="Circle"/>.
    /// </summary>
    [Fact]
    public void ShapeFactoryCreateCircle_GivesCircle()
    {
        ShapeFactory.CreateShape<Circle>().Should().BeOfType(typeof(Circle));
    }
}