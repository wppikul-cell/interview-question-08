namespace ExamSystem.Models.DTOs;

public class QuestionDto
{
    public int Id { get; set; }

    public string QuestionText { get; set; } = string.Empty;

    public List<QuestionChoiceDto> Choices { get; set; } = new();
}

