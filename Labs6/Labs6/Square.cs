public class Square : IGeometricFigure
{
    private readonly (double X, double Y)[] _vertices;

    public Square((double X, double Y)[] vertices)
    {
        if (vertices.Length != 4)
        {
            throw new ArgumentException("Square must have exactly 4 vertices.");
        }

        _vertices = vertices;
    }

    public double Area
    {
        get
        {
            var side = GetDistance(_vertices[0], _vertices[1]);
            return side * side;
        }
    }

    public double GetPerimeter()
    {
        var side = GetDistance(_vertices[0], _vertices[1]);
        return 4 * side;
    }

    public string GetInfo()
    {
        return $"квадрат | Цвет: N/A | Площадь: {Area:F2}";
    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= _vertices.Length * 2)
                throw new IndexOutOfRangeException();

            int i = index / 2;
            return index % 2 == 0 ? _vertices[i].X : _vertices[i].Y;
        }
    }

    private static double GetDistance((double X, double Y) a, (double X, double Y) b)
    {
        //Вычисляем растояние между точками
        var dx = a.X - b.X;
        var dy = a.Y - b.Y;
        var dist = Math.Sqrt(dx * dx + dy * dy);
        return dist;
    }
}
