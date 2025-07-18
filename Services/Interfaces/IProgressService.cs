public interface IProgressService
{
    Task<LessonDto> GetCurrentLessonForUserAsync(int userId);
    Task<bool> CompleteActivityAsync(int userId, int activityId, int? score);
}