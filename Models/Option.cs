namespace SimpleTodoApi.Models;

public class Option
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public bool IsCorrect { get; set; }

    // Foreign key to link back to the Question
    public int QuestionId { get; set; }
}