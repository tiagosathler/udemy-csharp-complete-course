namespace S06C78;

internal class Employee
{
    public short Id { get; }

    public string? Name { get; set; }

    public double Salary { get; private set; }

    public Employee(short id, string name, double salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public void IncreaseSalary(double percentage)
    {
        Salary *= 1 + (percentage / 100);
    }

    public override string ToString()
    {
        return $"{Id}, {Name}, $ {Salary:F2}";
    }
}