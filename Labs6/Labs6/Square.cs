using System.Drawing;

public class Square : IGeometricFigure
{
    private readonly (double X, double Y)[] _vertices;
    //Конструктор
    public Square((double X, double Y)[] vertices)

    {
        if (vertices.Length != 4)//Если не 4 вершины то исключение.
        {
            throw new ArgumentException("Square must have exactly 4 vertices.");
        }

        _vertices = vertices;
    }

    public double area
    {
        get
        {
            var side = GetDistance(_vertices[0], _vertices[1]);//Вычисление длинны одной стороны
            var s = side * side;//Площадь
            return s;
        }
    }

    public double GetPerimeter()
    {
        var side = GetDistance(_vertices[0], _vertices[1]);//Вычисление длинны одной стороны
        var s_cube = 4 * side;// Площадь куба
        return s_cube;
    }

    public string GetInfo()
    {
        return $"Cube | Color: N/A | Square: {area:F2}";
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
