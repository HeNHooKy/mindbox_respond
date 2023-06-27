namespace MindboxSquare.Shapes;

/// <summary>
/// Фигура - круг.
/// </summary>
public sealed class Circle : Shape
{
    private double _radius;
    
    public Circle()
    { }

    public Circle(double radius)
    {
        WithRadius(radius);
    }

    /// <summary>
    /// Установить радиус круга.
    /// </summary>
    /// <param name="radius">Новый радиус круга.</param>
    public void WithRadius(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Circle with a radius less or equal to zero cannot exist.");
        }
        
        _radius = radius;
        CompleteInitialization();
    }
    
    /// <inheritdoc />
    protected override double DoGetSquare()
    {
        return Math.PI * _radius * _radius;
    }
}