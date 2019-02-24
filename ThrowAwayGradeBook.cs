using System;
namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook");

            float lowest = float.MaxValue;

            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }

            grades.Remove(lowest);

            return base.ComputeStatistics();
        }
    }
}
