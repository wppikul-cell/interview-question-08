namespace ExamSystem.DTOs
{
    public class CreateQuestionDto
    {
        public string QuestionText { get; set; } = string.Empty;

        public List<CreateQuestionChoiceDto> Choices { get; set; } = new();
    }

    public class CreateQuestionChoiceDto
    {
        public string ChoiceText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
    }
}
