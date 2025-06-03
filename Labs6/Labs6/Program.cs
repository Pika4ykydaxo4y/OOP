public class Program
{
    public static void Main()
    {
        var parser = new FigureParser();
        var figures = parser.ParseFigures("figures.txt");

        Console.WriteLine("Номер | Вид фигуры | Цвет   | Площадь");

        int index = 1;
        foreach (var figure in figures)
        {
            Console.ResetColor();
            Console.Write($"{index,5} | ");
            Console.WriteLine(figure.GetInfo());
            index++;
        }

        Console.ResetColor();
    }
}
