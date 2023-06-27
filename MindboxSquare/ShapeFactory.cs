using MindboxSquare.Shapes;

namespace MindboxSquare;

/// <summary>
/// Фабрика фигур.
/// </summary>
public static class ShapeFactory
{
    /// <summary>
    /// Создать фигуру указанного типа.
    /// </summary>
    /// <returns></returns>
    public static TShape CreateShape<TShape>()
        where TShape : Shape, new()
    {
        return new TShape();
    }

    /// <summary>
    /// Создать круг с указанным радиусом.
    /// </summary>
    /// <param name="radius">Радиус круга.</param>
    /// <returns>Подготовленный круг.</returns>
    public static Circle CreateCircle(double radius)
    {
        return new Circle(radius);
    }

    /// <summary>
    /// Создать треугольник с заданными сторонами.
    /// </summary>
    /// <param name="aSide">Первая сторона.</param>
    /// <param name="bSide">Вторая сторона.</param>
    /// <param name="cSide">Третья сторона.</param>
    /// <returns>Подготовленный треугольник.</returns>
    public static Triangle CreateTriangle(int aSide, int bSide, int cSide)
    {
        return new Triangle(aSide, bSide, cSide);
    }
}