namespace MindboxSquare.Shapes;

/// <summary>
/// Фигура - круг.
/// </summary>
public sealed class Circle : Shape
{
    private double _radius;
    
    internal Circle()
    {
    }

    public Circle(double radius)
    {
        _radius = radius;
        CompleteInitialization();
    }

    /// <summary>
    /// Установить радиус круга.
    /// </summary>
    /// <param name="radius">Новый радиус круга.</param>
    public void WithRadius(double radius)
    {
        _radius = radius;
        CompleteInitialization();
    }
    
    /// <inheritdoc />
    protected override double DoGetSquare()
    {
        return Math.PI * _radius * _radius;
    }
}