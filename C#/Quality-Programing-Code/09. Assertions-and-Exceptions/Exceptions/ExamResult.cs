using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new IndexOutOfRangeException("Grade should be positive");
        }

        if (minGrade < 0)
        {
            throw new IndexOutOfRangeException("MinGrade should be positive");
        }

        if (maxGrade <= minGrade)
        {
            throw new IndexOutOfRangeException("MaxGrade cannot be lesser than MinGrade");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentException("Comments cannot be null or empty string");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
