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

    public double area
    {
        get
        {
            var side = GetDistance(_vertices[0], _vertices[1]);
            var s = side * side;
            return s;
        }
    }

    public double GetPerimeter()
    {
        var side = GetDistance(_vertices[0], _vertices[1]);
        var s_cube = 4 * side;
        return s_cube;
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
            var value = index % 2 == 0 ? _vertices[i].X : _vertices[i].Y;
            return value;
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
