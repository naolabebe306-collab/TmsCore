using System.Diagnostics;

public static class Exercise6
{
    public static async Task Run()
    {
        var sw = Stopwatch.StartNew();

        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(300);
        }

        Console.WriteLine($"Blocking sequential: {sw.ElapsedMilliseconds}ms");

        sw.Restart();

        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(300);
        }

        Console.WriteLine($"Async sequential: {sw.ElapsedMilliseconds}ms");

        sw.Restart();

        var tasks = Enumerable.Range(0, 5)
            .Select(_ => Task.Delay(300));

        await Task.WhenAll(tasks);

        Console.WriteLine($"Async parallel: {sw.ElapsedMilliseconds}ms");

        Console.WriteLine();

        string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];

        var studentTasks =
            studentIds.Select(id => FetchStudentAsync(id));

        Student[] students =
            await Task.WhenAll(studentTasks);

        var enrollCourse = new Course
        {
            Code = "CRS-101",
            Title = "C# Mastery",
            Capacity = 2
        };

        var enrollService = new EnrollmentService();

        var enrollments = new List<EnrollmentRecord>();
        var failures = new List<string>();

        sw.Restart();

        foreach (var student in students)
        {
            try
            {
                var record =
                    enrollService.ProcessRegistration(
                        student,
                        enrollCourse);

                enrollCourse.EnrolledCount++;

                enrollments.Add(record);

                Console.WriteLine($"Enrolled: {student.Name}");
            }
            catch (CapacityReachedException ex)
            {
                failures.Add(
                    $"{student.Name}: {ex.Message}");

                Console.WriteLine(
                    $"Rejected: {student.Name}");
            }
        }

        sw.Stop();

        decimal classAverage =
            students.Average(s => s.GPA);

        Console.WriteLine();
        Console.WriteLine("========== ENROLLMENT SUMMARY ==========");
        Console.WriteLine($"Total students loaded: {students.Length}");
        Console.WriteLine($"Successful enrollments: {enrollments.Count}");
        Console.WriteLine($"Failed enrollments: {failures.Count}");
        Console.WriteLine($"Class average GPA: {classAverage:F2}");
        Console.WriteLine($"Total elapsed time: {sw.ElapsedMilliseconds}ms");

        if (failures.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("--- Failure Details ---");

            foreach (var failure in failures)
            {
                Console.WriteLine(failure);
            }
        }

        Console.WriteLine("========================================");
    }

    private static async Task<Student> FetchStudentAsync(string id)
    {
        await Task.Delay(300);

        return new Student
        {
            Id = id,
            Name = $"Student-{id}",
            Age = 20,
            GPA = id switch
            {
                "S1" => 3.8m,
                "S2" => 2.4m,
                "S3" => 3.5m,
                "S4" => 1.9m,
                "S5" => 3.2m,
                _ => 2.5m
            }
        };
    }
}