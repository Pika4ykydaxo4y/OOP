using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    private string lastName;
    private string department;
    private double[] salaries;

    public Employee(string lastName, string department, double[] salaries)
    {
        this.lastName = lastName;
        this.department = department;
        this.salaries = salaries;
    }

    public string LastName => lastName;
    public string Department => department;
    public double AverageSalary => salaries.Average();

    // Индексатор который позволяет получать и изменять зарплаты сотрудника по индексу
    public double this[int index]
    {
        get { return salaries[index]; }
        set { salaries[index] = value; }
    }

    public double MaxSalary => salaries.Max();
}
