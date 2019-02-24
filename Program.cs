using System;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = new ThrowAwayGradeBook();

            GetName(book);
            AddGrades(book);
            GetResult(book);
            SaveResult(book);
        }

        private static void SaveResult(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.text"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void GetResult(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Average", (int)stats.AverageGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(90);
            book.AddGrade(85);
            book.AddGrade(70);
        }

        private static void GetName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name:");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }


        static void WriteResult(string description, int result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: ${result}");
        }
    }
}
