public static class Exercise2
{
    public static void Run()
    {
        double grantPerStudentLegacy = 1999.99;
        double totalAllocationLegacy = grantPerStudentLegacy * 100_000;

        Console.WriteLine($"Total allocated (double): {totalAllocationLegacy}");

        decimal grantPerStudent = 1999.99m;
        decimal totalAllocation = grantPerStudent * 100_000m;

        Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
        Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");
    }
}