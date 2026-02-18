//“Student Marks Analyzer” — store marks for multiple subjects and print a performance report. Use 1D arrays for single student, 2D arrays for class marks matrix, and jagged arrays when subjects differ per student.
using System;
class StudentMarksAnalyzer
{
    public static void main()
    {
        // 1D array for a single student's marks
        int[] studentMarks = new int[] { 85, 90, 78, 92, 88 };
        Console.WriteLine("Single Student Marks:");
        for (int i = 0; i < studentMarks.Length; i++)
        {
            Console.Write(studentMarks[i] + " ");
        }
        Console.WriteLine("\n");

        // 2D array for class marks matrix
        int[,] classMarks = new int[,]
        {
            { 85, 90, 78 },
            { 88, 76, 95 },
            { 92, 89, 84 }
        };
        Console.WriteLine("Class Marks Matrix:");
        for (int i = 0; i < classMarks.GetLength(0); i++)
        {
            for (int j = 0; j < classMarks.GetLength(1); j++)
            {
                Console.Write(classMarks[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Jagged array for subjects differing per student
        int[][] jaggedMarks = new int[3][];
        jaggedMarks[0] = new int[] { 85, 90 }; // Student 1 has 2 subjects
        jaggedMarks[1] = new int[] { 78, 88, 92 }; // Student 2 has 3 subjects
        jaggedMarks[2] = new int[] { 95 }; // Student 3 has 1 subject

        Console.WriteLine("Jagged Array of Student Marks:");
        for (int i = 0; i < jaggedMarks.Length; i++)
        {
            for (int j = 0; j < jaggedMarks[i].Length; j++)
            {
                Console.Write(jaggedMarks[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}