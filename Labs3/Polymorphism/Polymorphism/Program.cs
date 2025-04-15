namespace Polymorphism
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Tool> tools = new List<Tool>
            {
                new Hammer(),
                new Wrench(),
                new Drill()
            };

            foreach (Tool tool in tools)
            {

                var toolsCount = tool.Use();
                Console.WriteLine(toolsCount);
            }
        }
    }
}
