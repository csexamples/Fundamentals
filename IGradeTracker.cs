using System.IO;

namespace Grades
{
    public interface IGradeTracker
    {
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        void AddGrade(float grade);
        string Name { get; set; }
    }
}