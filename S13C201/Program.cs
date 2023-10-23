using S13C201.Exceptions;

namespace S13C201;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        try
        {
            string path = GetDirectoryFullPath();

            List<string> sourceContentLines = GetSourceContent(path, "source_data.csv");

            List<string> computedOutputLines = ComputeOutputLines(sourceContentLines);

            WriteOutputFile(computedOutputLines, path, "output_data.csv");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred!");
            Console.WriteLine(ex.Message);
        }
    }

    private static string GetDirectoryFullPath()
    {
        Console.Write("Enter the full path of the directory containing the 'source_data.csv' file or press enter for the default value: ");
        string? path = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(path))
        {
            DirectoryInfo projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!;
            return projectDirectory.FullName + @"\files\";
        }

        return path.Trim();
    }

    private static List<string> GetSourceContent(string basePath, string filename)
    {
        List<string> lines = new();

        using (StreamReader sr = File.OpenText(basePath + filename))
        {
            while (!sr.EndOfStream)
            {
                lines.Add(sr.ReadLine()!);
            }
        }

        return lines;
    }

    private static List<string> ComputeOutputLines(List<string> csvContentLines)
    {
        List<string> outputLines = new();

        foreach (string line in csvContentLines)
        {
            string[] fields = line.Split(",");

            if (fields.Length != 3)
            {
                throw new InvalidFormatException("Invalid format in source file! The CSV file must have 3 fields: name, value, quantity.");
            }

            string name = fields[0];
            double value = double.Parse(fields[1]);
            int quantity = int.Parse(fields[2]);

            outputLines.Add($"{name},{value * quantity:F2}");
        }

        return outputLines;
    }

    private static void WriteOutputFile(List<string> outputLines, string path, string filename)
    {
        string outputPath = Directory.Exists(path + @"\out") ? path + @"\out\" : Directory.CreateDirectory(path + @"\out").FullName + Path.DirectorySeparatorChar;

        outputLines.Sort(StringComparer.OrdinalIgnoreCase);

        using StreamWriter sw = File.CreateText(outputPath + filename);
        sw.WriteLine("product_name,total_value");

        foreach (string line in outputLines)
        {
            sw.WriteLine(line);
        }
    }
}