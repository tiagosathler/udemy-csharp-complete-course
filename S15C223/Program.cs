namespace S15C223;

internal static class Program
{
    private static void Main(string[] args)
    {
        string[] contentData = GetInputData();

        SortedDictionary<string, int> poll = GetVotesFromInputData(contentData);

        Console.WriteLine("Total votes:");

        int maxVotes = 0;
        int totalVotes = 0;
        string elected = "";

        foreach (KeyValuePair<string, int> kv in poll)
        {
            Console.WriteLine($"{kv.Key}: {kv.Value}");

            if (kv.Value > maxVotes)
            {
                maxVotes = kv.Value;
                elected = kv.Key;
            }

            totalVotes += kv.Value;
        }

        double percentage = 100.0 * poll[elected] / totalVotes;

        Console.WriteLine($"\n\x1b[1mElected: {elected} - {poll[elected]} votes ({percentage:F2}%)\x1b[0m");
    }

    private static SortedDictionary<string, int> GetVotesFromInputData(string[] contentData)
    {
        SortedDictionary<string, int> poll = new();

        foreach (string line in contentData)
        {
            string[] fields = line.Split(',');

            string name = fields[0];
            int votes = int.Parse(fields[1]);

            if (!poll.ContainsKey(name))
            {
                poll[name] = votes;
            }
            else
            {
                poll[name] += votes;
            }
        }

        return poll;
    }

    private static string[] GetInputData()
    {
        DirectoryInfo currentDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!;

        // another way: DirectoryInfo currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!;

        string path = Path.Combine(currentDirectory.FullName, @"files\input.csv");

        return File.ReadAllLines(path);
    }
}