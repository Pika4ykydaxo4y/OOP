public class Program
{
    public static void Main()
    {
        var parser = new FigureParser();
        var figures = parser.ParseFigures("figures.txt");

        Console.WriteLine("Number | Type figure | Color   | Square");

        int index = 1;
        foreach (var figure in figures)
        {
            Console.ResetColor();
            //Отступ
            Console.Write($"{index,5} | ");
            Console.WriteLine(figure.GetInfo());
            index++;
        }

        Console.ResetColor();
    }
}
