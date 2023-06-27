namespace MindboxSquare;

/// <summary>
/// Предоставляет возможность получить площадь фигуры.
/// </summary>
public interface ISquareComputable
{
    /// <summary>
    /// Получить площадь фигуры.
    /// </summary>
    /// <returns>Площадь фигуры.</returns>
    public double GetSquare();
}