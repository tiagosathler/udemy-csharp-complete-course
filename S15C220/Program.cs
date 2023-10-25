using S15C220.Entities;

namespace S15C220;

internal static class Program
{
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        string[] contentInputData = GetInputData();

        HashSet<LogRecord> logRecordSet = GenerateSet<HashSet<LogRecord>, LogRecord>(contentInputData);
        SortedSet<LogRecord> logRecordSortedSet = GenerateSet<SortedSet<LogRecord>, LogRecord>(contentInputData);

        PrintLogRecords(nameof(logRecordSet), logRecordSet);
        PrintLogRecords(nameof(logRecordSortedSet), logRecordSortedSet);

        LogRecord amanda = new("amanda", DateTime.Now);
        LogRecord ana = new("ana", DateTime.Now);

        TestContains(nameof(logRecordSet), logRecordSet, amanda);
        TestContains(nameof(logRecordSortedSet), logRecordSortedSet, amanda);

        TestContains(nameof(logRecordSet), logRecordSet, ana);
        TestContains(nameof(logRecordSortedSet), logRecordSortedSet, ana);

        TestOperators(amanda, amanda);
        TestOperators(amanda, ana);
        TestOperators(ana, amanda);
        TestOperators(null, amanda);
        TestOperators(amanda, null);
        TestOperators(null, null);
    }

    private static string[] GetInputData()
    {
        DirectoryInfo currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!;
        string path = Path.Combine(currentDirectory.FullName, @"files\input.txt");

        return File.ReadAllLines(path);
    }

    private static S GenerateSet<S, L>(string[] contentInputData)
        where S : notnull, ISet<L>, new()
        where L : notnull, LogRecord, IComparable, new()
    {
        S set = new();

        foreach (string line in contentInputData)
        {
            LogRecord logRecord = new();

            string[] values = line.Split(' ');

            logRecord.UserName = values[0];
            logRecord.Instant = DateTime.Parse(values[1], Thread.CurrentThread.CurrentCulture, System.Globalization.DateTimeStyles.AssumeLocal);

            set.Add((L)logRecord);
        }

        return set;
    }

    private static void PrintLogRecords<T>(string collectionName, ICollection<T> collection)
    {
        Console.WriteLine($"\n\x1b[1m{collectionName} (Total users: {collection.Count}):\x1b[0m");

        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
    }

    private static void TestContains(string setName, ISet<LogRecord> set, LogRecord p1)
    {
        Console.WriteLine($"\nDoes '{setName}' contain '{p1.UserName}'? {set.Contains(p1)}");
    }

    private static void TestOperators(LogRecord? p1, LogRecord? p2)
    {
        string name1 = p1?.UserName ?? "null";
        string name2 = p2?.UserName ?? "null";

        Console.WriteLine();

        Console.WriteLine($"{name1} == {name2} = {p1 == p2}");
        Console.WriteLine($"{name1} != {name2} = {p1 != p2}");
        Console.WriteLine($"{name1} >  {name2} = {p1 > p2}");
        Console.WriteLine($"{name1} >= {name2} = {p1 >= p2}");
        Console.WriteLine($"{name1} <  {name2} = {p1 < p2}");
        Console.WriteLine($"{name1} <= {name2} = {p1 <= p2}");

        Console.WriteLine();
    }
}