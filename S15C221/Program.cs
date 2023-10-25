namespace S15C221;

internal static class Program
{
    private static void Main(string[] args)
    {
        int numberOfClasses = GetIntNumber("Enter the number of classes");

        List<HashSet<int>> classes = new();

        for (int classNumber = 1; classNumber <= numberOfClasses; classNumber++)
        {
            HashSet<int> currentClass = GetStudentEnrollments(classNumber);
            classes.Add(currentClass);
        }

        HashSet<int> allClasses = new();

        foreach (HashSet<int> currentClass in classes)
        {
            allClasses.UnionWith(currentClass);
        }

        Console.WriteLine($"\n\x1b[1mTOTAL STUDENTS: {allClasses.Count}\x1b[0m");
    }

    private static HashSet<int> GetStudentEnrollments(int classNumber)
    {
        HashSet<int> studentEnrollments = new();

        Console.WriteLine($"\n\nRegistering the enrollment of class {classNumber} students");

        int numberOfStudents = GetIntNumber("Enter the number of students");

        for (int student = 1; student <= numberOfStudents; student++)
        {
            int enrollment;
            bool isItIncluded;

            do
            {
                enrollment = GetIntNumber($"Student enrollment #{student}");
                isItIncluded = studentEnrollments.Contains(enrollment);

                if (isItIncluded)
                {
                    Console.WriteLine($"This enrollment #{enrollment} already included! Enter again!");
                }
            } while (isItIncluded);

            studentEnrollments.Add(enrollment);
        }

        return studentEnrollments;
    }

    private static int GetIntNumber(string message)
    {
        int number;

        do
        {
            Console.Write($"{message}: ");
        } while (!int.TryParse(Console.ReadLine(), out number) && number <= 0);

        return number;
    }
}