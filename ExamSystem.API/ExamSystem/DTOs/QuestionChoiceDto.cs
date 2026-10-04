namespace ExamSystem.Models.DTOs;

public class QuestionChoiceDto
{
    public int Id { get; set; }


    public string ChoiceText { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }
}

