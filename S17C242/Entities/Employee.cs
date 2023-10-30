namespace S17C242.Entities
{
    internal readonly struct Employee
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public double Salary { get; init; }

        public Employee(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override bool Equals(object? obj)
        {
            return obj is Employee employee &&
            Name.Equals(employee.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        public override string ToString()
        {
            return $"{Name} - {Email} - Salary: ${Salary:F2}";
        }
    }
}