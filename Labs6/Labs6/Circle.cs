//Реализуем интерфейс
public class Circle : IGeometricFigure
{
    //Параметры круга, только чтение
    private readonly double _radius;
    private readonly (double X, double Y) _center;
    private readonly string _color;

    //Конструктор
    public Circle((double X, double Y) center, double radius, string color)
    {
        //Параметры
        _center = center;
        _radius = radius;
        _color = color;
    }

    //Формула площади
    public double Area => Math.PI * _radius * _radius;

    //Длинна окружности
    public double GetPerimeter() => 2 * Math.PI * _radius;

    public string GetInfo()
    {
        //Здесь мы пытаемся преобразовать строку в одно из значений enum. Если успешно то цвет, если нет то беляй.
        Console.ForegroundColor = Enum.TryParse<ConsoleColor>(_color, true, out var color)
            ? color : ConsoleColor.White;

        return $"круг | Цвет: {_color} | Площадь: {Area:F2}";
    }

    public double this[int index]
    {
        //Получаем значение по индексу и возвращаем его.
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
