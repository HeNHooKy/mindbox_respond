namespace MindboxSquare.Shapes;

/// <summary>
/// Фигура - треугольник.
/// </summary>
public sealed class Triangle : Shape
{
    // Треугольник будем определять целыми числами, так как при работе с вещественными имеем кучу проблем.
    // В задаче не оговорено требуется ли решать эти проблемы.
    // TODO: Уточнить, нужна ли поддержка вещественных чисел.
    private int _aSide;
    private int _bSide;
    private int _cSide;

    internal Triangle()
    { }

    /// <param name="aSide">Первая сторона.</param>
    /// <param name="bSide">Вторая сторона.</param>
    /// <param name="cSide">Третья сторона.</param>
    public Triangle(int aSide, int bSide, int cSide)
    {
        _aSide = aSide;
        _bSide = bSide;
        _cSide = cSide;
        
        CompleteInitialization();
    }

    /// <summary>
    /// Проинициализирвоать треугольник со сторонами.
    /// </summary>
    /// <param name="aSide">Первая сторона.</param>
    /// <param name="bSide">Вторая сторона.</param>
    /// <param name="cSide">Третья сторона.</param>
    public void WithSides(int aSide, int bSide, int cSide)
    {
        _aSide = aSide;
        _bSide = bSide;
        _cSide = cSide;
        
        CompleteInitialization();
    }

    /// <inheritdoc cref="IsRightAngledBase"/>
    /// <exception cref="ApplicationException">Фигура не проинициализирована (Одна из базовых характеристик фигуры не задана).</exception>
    public bool IsRightAngled()
    {
        ValidateInitialized();
        return IsRightAngledBase();
    }

    /// <inheritdoc />
    protected override double DoGetSquare()
    {
        if (_aSide == _bSide && _bSide == _cSide)
        {
            return Constants.RootOfThreeDividedByFour * _aSide * _aSide;
        }
        
        if (IsRightAngledBase())
        {
            return (double)_aSide * _bSide / 2;
        }

        var p = (double)(_aSide + _bSide + _cSide) / 2;

        return Math.Sqrt(p * (p - _aSide) * (p - _bSide) * (p - _cSide));
    }

    /// <summary>
    /// Является ли треугольник прямоугольным.
    /// </summary>
    /// <returns>True - треугольник прямоугольный.</returns>
    private bool IsRightAngledBase()
    {
        return _aSide * _aSide + _bSide * _bSide == _cSide * _cSide
               || _aSide * _aSide + _cSide * _cSide == _bSide * _bSide
               || _cSide * _cSide + _bSide * _bSide == _aSide * _aSide;
    }
}