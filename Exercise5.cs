using System.Linq;

public static class Exercise5
{
    public static void Run()
    {
        List<Student> students =
        [
            new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
            new Student { Id = "S2", Name = "Kidane", Age = 21, GPA = 2.4m },
            new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
            new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
            new Student { Id = "S5", Name = "Frehiwot", Age = 19, GPA = 2.0m },
            new Student { Id = "S6", Name = "Yonas", Age = 24, GPA = 3.5m },
            new Student { Id = "S7", Name = "Meron", Age = 22, GPA = 1.8m },
            new Student { Id = "S8", Name = "Tesfaye", Age = 21, GPA = 2.9m }
        ];

        var leaderboard = students
            .Where(s => s.GPA >= 3.5m)
            .OrderByDescending(s => s.GPA)
            .Select(s => s.Name)
            .ToList();

        Console.WriteLine($"Found {leaderboard.Count} Honors Students:");

        foreach (var name in leaderboard)
        {
            Console.WriteLine($"- {name}");
        }

        decimal averageGpa = students.Average(s => s.GPA);

        Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");

        var standingGroups = students.GroupBy(s => s.GPA switch
        {
            >= 3.5m => "Honors",
            >= 2.5m => "Good Standing",
            >= 2.0m => "Probation",
            _ => "Academic Warning"
        });

        Console.WriteLine("\n--- Academic Standing Report ---");

        foreach (var group in standingGroups)
        {
            Console.WriteLine($"\n{group.Key} ({group.Count()}):");

            foreach (var s in group)
            {
                Console.WriteLine($" {s.Name} GPA: {s.GPA}");
            }
        }

        string[] backendCourses = ["C#", "ASP.NET Core"];
        string[] frontendCourses = ["TypeScript", "Angular"];

        string[] allCourses =
        [
            ..backendCourses,
            ..frontendCourses,
            "Capstone"
        ];

        Console.WriteLine(
            $"\nFull curriculum: {string.Join(", ", allCourses)}");
    }
}