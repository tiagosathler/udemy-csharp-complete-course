namespace S09C128.Entities;

internal class Department
{
    public string? Name { get; set; }

    public Department()
    {
    }

    public Department(string name)
    {
        Name = name;
    }
}