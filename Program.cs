await Exercise6.Run();

Console.WriteLine();
Console.WriteLine("===== Exercise 7 =====");

var service = new EnrollmentService();

try
{
    var overflowCourse = new Course
    {
        Code = "CRS-999",
        Title = "Overflow Test",
        Capacity = 0
    };

    service.ProcessRegistration(
        new Student
        {
            Id = "S99",
            Name = "Test",
            Age = 20,
            GPA = 3.0m
        },
        overflowCourse);
}
catch (CapacityReachedException ex)
{
    Console.WriteLine("Domain exception caught");
    Console.WriteLine($"Course: {ex.CourseCode}");
    Console.WriteLine($"Message: {ex.Message}");
}