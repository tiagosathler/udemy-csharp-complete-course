using S09C131.Entities;

namespace S09C131;

internal static class Program
{
    public static readonly string DATE_TIME_FORMAT = "dd/MM/yyyy HH:mm:ss";

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Post post1 = new(
            DateTime.ParseExact("21/06/2018 13:05:44", DATE_TIME_FORMAT, Thread.CurrentThread.CurrentCulture),
            "Traveling to New Zealand",
            "I'm going to visit the wonderful country!",
            12
        );

        post1.AddComment(new Comment("Have a nice trip"));
        post1.AddComment(new Comment("Wow that's awesome!"));

        Post post2 = new(
            DateTime.ParseExact("28/07/2018 23:14:19", DATE_TIME_FORMAT, Thread.CurrentThread.CurrentCulture),
            "Good night guys",
            "See you tomorrow",
            5
        );

        post2.AddComment(new Comment("Good night"));
        post2.AddComment(new Comment("May the Force be with you"));

        Console.WriteLine(post1);
        Console.WriteLine();

        Console.WriteLine(post2);
        Console.WriteLine();
    }
}