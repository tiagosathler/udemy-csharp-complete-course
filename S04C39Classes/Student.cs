namespace S04C39Classes;

internal class Student
{
    public string ?Name { get; set; }
    public List<double> grades = new();

    public void AddGrade(double grade)
    {
        grades.Add(grade);
    }

    public double FinalGrade()
    {
        return grades.Sum();
    }
}
