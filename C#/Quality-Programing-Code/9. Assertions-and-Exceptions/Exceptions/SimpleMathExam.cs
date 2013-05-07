using System;

public class SimpleMathExam : Exam
{
    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || problemsSolved > 3)
        {
            throw new ArgumentException("Problems should be in range [1..3]");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        ExamResult examResult = null; 

        if (this.ProblemsSolved == 0)
        {
            examResult = new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            examResult = new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            examResult = new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return examResult;
    }
}
