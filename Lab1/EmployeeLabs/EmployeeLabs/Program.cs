class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("count: ");
        int employeeCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < employeeCount; i++)
        {
            Console.Write("Surname: ");
            string lastName = Console.ReadLine();

            Console.Write("Department: ");
            string department = Console.ReadLine();

            Console.Write("Enter salaries for n months: ");
            double[] salaries = Console.ReadLine().Split().Select(double.Parse).ToArray();

            employees.Add(new Employee(lastName, department, salaries));
        }

        // Вывод списка сотрудников по возрастанию средней зарплаты
        Console.WriteLine("\nList of employees with average salary:");
        foreach (var emp in employees.OrderBy(e => e.AverageSalary))
        {
            Console.WriteLine($"{emp.LastName} ({emp.Department}) - Average salary: {emp.AverageSalary:F2}");
        }

        // Макс зп по отделу
        Console.WriteLine("\nMaximum salary by department:");
        var maxSalariesByDept = employees.GroupBy(e => e.Department)
            .Select(g => new { Department = g.Key, MaxSalary = g.Max(e => e.MaxSalary) });

        foreach (var dept in maxSalariesByDept)
        {
            Console.WriteLine($"{dept.Department}: {dept.MaxSalary:F2}");
        }

        // Средняя по палате
        double avgCompanySalary = employees.Average(e => e.AverageSalary);

        Console.WriteLine("\nEmployees with salaries 5% higher than the company average:");
        var highEarners = employees.Where(e => e.AverageSalary > avgCompanySalary * 1.05);

        if (highEarners.Any())
        {
            foreach (var employee in highEarners)
            {
                Console.WriteLine($"{employee.LastName} ({employee.Department}) -  Average salary: {employee.AverageSalary:F2}");
            }
        }
        else
        {
            Console.WriteLine("No employees exceeding the threshold.");
        }
    }
}
