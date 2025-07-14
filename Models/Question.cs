using System.Collections.Generic;

namespace SimpleTodoApi.Models;

public class Question
{
    public int Id { get; set; }
    public string? Text { get; set; }

    // Navigation property for the related options
    public List<Option> Options { get; set; } = new List<Option>();
}