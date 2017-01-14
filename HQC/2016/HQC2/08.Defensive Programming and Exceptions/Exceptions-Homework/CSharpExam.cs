using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new InvalidScoreValueException("Score cannot be less than zero!");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        if (Score < 0 || Score > 100)
        {
            throw new InvalidScoreValueException("Score cannot be less than zero and more than 100!");
        }
        else
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}

public class InvalidScoreValueException : Exception
{
    public InvalidScoreValueException()
    {
    }

    public InvalidScoreValueException(string message)
        : base(message)
    {
    }

    public InvalidScoreValueException(string message, Exception inner)
        : base(message, inner)
    {
    }
}