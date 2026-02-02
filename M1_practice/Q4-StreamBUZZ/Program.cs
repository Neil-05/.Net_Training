using System;
using System.Collections.Generic;
using System.Linq;

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }

    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
}

public class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;
        Program program = new Program();

        do
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Creator Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    double[] likes = new double[4];
                    for (int i = 0; i < 4; i++)
                    {
                        likes[i] = double.Parse(Console.ReadLine());
                    }

                    CreatorStats record = new CreatorStats
                    {
                        CreatorName = name,
                        WeeklyLikes = likes
                    };

                    program.RegisterCreator(record);
                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    Dictionary<string, int> result =
                        program.GetTopPostCounts(
                            CreatorStats.EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    break;

                case 3:
                    if (CreatorStats.EngagementBoard.Count == 0)
                    {
                        Console.WriteLine("Overall average weekly likes: 0");
                    }
                    else
                    {
                        double avg = CreatorStats.EngagementBoard
                            .SelectMany(c => c.WeeklyLikes)
                            .Average();

                        Console.WriteLine(
                            $"Overall average weekly likes: {Math.Round(avg)}");
                    }
                    break;

                case 4:
                    Console.WriteLine(
                        "Logging off - Keep Creating with StreamBuzz!");
                    exit = true;
                    break;
            }

        } while (!exit);
    }

    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    public Dictionary<string, int> GetTopPostCounts(
        List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result =
            new Dictionary<string, int>();

        foreach (var creator in records)
        {
            int count = creator.WeeklyLikes
                .Count(like => like >= likeThreshold);

            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }
}
