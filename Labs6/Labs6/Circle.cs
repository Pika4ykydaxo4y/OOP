public class Circle : IGeometricFigure
{
    private readonly double _radius;
    private readonly (double X, double Y) _center;
    private readonly string _color;

    public Circle((double X, double Y) center, double radius, string color)
    {
        _center = center;
        _radius = radius;
        _color = color;
    }

    public double Area => Math.PI * _radius * _radius;

    public double GetPerimeter() => 2 * Math.PI * _radius;

    public string GetInfo()
    {
        Console.ForegroundColor = Enum.TryParse<ConsoleColor>(_color, true, out var color)
            ? color : ConsoleColor.White;

        return $"круг | Цвет: {_color} | Площадь: {Area:F2}";
    }

    public double this[int index]
    {
        get
        {
            return index switch
            {
                0 => _center.X,
                1 => _center.Y,
                2 => _radius,
                _ => throw new IndexOutOfRangeException()
            };
        }
    }
}
