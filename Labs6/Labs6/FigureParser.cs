public class FigureParser
{
    private string color;

    public List<IGeometricFigure> ParseFigures(string filePath)
    {
        var figures = new List<IGeometricFigure>();
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 9) // Значение 9 потому что 4 координаты(x,y) + цвет
            {
                var vertices = new (double X, double Y)[4];
                for (int i = 0; i < 4; i++)
                {
                    vertices[i] = (double.Parse(parts[i * 2]), double.Parse(parts[i * 2 + 1]));
                }
                figures.Add(new Square(vertices));
            }
            else if (parts.Length == 4) // круг: центр X, Y, радиус, цвет
            {
                var center = (double.Parse(parts[0]), double.Parse(parts[1]));
                var radius = double.Parse(parts[2]);
                var color = parts[3];
                figures.Add(new Circle(center, radius, color));
            }
        }

        return figures;
    }
}
