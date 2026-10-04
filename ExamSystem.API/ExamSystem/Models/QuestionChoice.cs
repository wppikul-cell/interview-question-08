namespace ExamSystem.Models;

public class QuestionChoice
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string ChoiceText { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }
    public Question? Question { get; set; }
}

