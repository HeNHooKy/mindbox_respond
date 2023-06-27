namespace MindboxSquare;

/// <summary>
/// Тип базовой фигуры.
/// </summary>
public abstract class Shape : ISquareComputable
{
    /// <summary>
    /// Указывает на инициализированность фигуры.
    /// </summary>
    private bool _initialized = false;
    
    public Shape() { }

    /// <inheritdoc />
    /// <exception cref="ApplicationException">Фигура не проинициализирована (Одна из базовых характеристик фигуры не задана).</exception>
    public double GetSquare()
    {
        ValidateInitialized();
        return DoGetSquare();
    }

    /// <summary>
    /// Проверить, что фигура полностью проинициализирована.
    /// </summary>
    /// <exception cref="ApplicationException">Фигура не проинициализирована (Одна из базовых характеристик фигуры не задана).</exception>
    protected void ValidateInitialized()
    {
        if (_initialized is false)
        {
            throw new ApplicationException($"{GetType().FullName} isn't initialized to make any calculation.");
        }
    }
    
    /// <summary>
    /// Сообщить о завершении инициализации фигуры.
    /// </summary>
    protected void CompleteInitialization()
    {
        _initialized = true;
    }
    
    /// <summary>
    /// Выполнить вычисление площади фигуры.
    /// </summary>
    /// <returns>Площадь фигуры.</returns>
    protected abstract double DoGetSquare();
}