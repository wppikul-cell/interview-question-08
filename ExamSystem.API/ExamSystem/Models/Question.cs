namespace ExamSystem.Models;

public class Question
{
    public int Id { get; set; }

    public string QuestionText { get; set; } = string.Empty;

    public ICollection<QuestionChoice> Choices { get; set; }
        = new List<QuestionChoice>();
}

