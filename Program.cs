#nullable enable

var service = new EnrollmentService();


var validStudent = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m
};

var validCourse = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30
};

var result = service.ProcessRegistration(validStudent, validCourse);

Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode}");

Console.WriteLine();



try
{
    service.ProcessRegistration(null, validCourse);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Guard caught: {ex.ParamName}");
}

Console.WriteLine();



var fullCourse = new Course
{
    Code = "CS-402",
    Title = "Full Course",
    Capacity = 1,
    EnrolledCount = 1
};

try
{
    service.ProcessRegistration(validStudent, fullCourse);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Business rule: {ex.Message}");
}