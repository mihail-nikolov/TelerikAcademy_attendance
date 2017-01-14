using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new InvalidGradeValueException("Grade cannot be less than zero!");
        }
        if (minGrade < 0)
        {
            throw new InvalidGradeValueException("Min Grade cannot be less than zero!");
        }
        if (maxGrade <= minGrade)
        {
            throw new InvalidGradeValueException("Max Grade cannot be less than Min Grade!");
        }

        if (comments == null || comments == "")
        {
            throw new CommentNotAvailable("Comments cannot be empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}

public class InvalidGradeValueException: Exception
{
    public InvalidGradeValueException()
    {
    }

    public InvalidGradeValueException(string message)
        : base(message)
    {
    }

    public InvalidGradeValueException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class CommentNotAvailable : Exception
{
    public CommentNotAvailable()
    {
    }

    public CommentNotAvailable(string message)
        : base(message)
    {
    }

    public CommentNotAvailable(string message, Exception inner)
        : base(message, inner)
    {
    }
}