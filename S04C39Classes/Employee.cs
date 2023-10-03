namespace S04C39Classes;

internal class Employee
{
    public string ?Name { get; set; }
    public double GrossSalary { get; set; }
    public double Tax { get; set; }

    public double NetSalary()
    {
        return GrossSalary - Tax;
    }

    public void IncreaseSalary(double percentage)
    {
        GrossSalary *= (1 + percentage / 100);
    }

    override public string ToString()
    {
        return $"{Name}, $ {NetSalary():F2}";
    }
}