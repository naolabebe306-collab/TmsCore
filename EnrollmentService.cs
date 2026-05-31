public class EnrollmentService
{
    public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
    {
        

        if (student is null)
            throw new ArgumentNullException(nameof(student));

        if (course is null)
            throw new ArgumentNullException(nameof(course));

        if (course.Capacity <= 0)
            throw new InvalidOperationException("Course capacity must be greater than zero.");

        if (course.EnrolledCount >= course.Capacity)
            throw new InvalidOperationException("Course is full.");

        

        string standing = student.GPA switch
        {
            >= 3.5m => "Honors",
            >= 2.5m => "Good Standing",
            < 2.5m => "Academic Warning"
        };

        Console.WriteLine($"{student.Name} is in {standing}.");


        return new EnrollmentRecord(
            student.Id,
            course.Code,
            DateTime.UtcNow
        );
    }
}