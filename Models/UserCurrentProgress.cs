namespace TamilApp.Core.Models
{
    public class UserCurrentProgress
    {
        // This forms a one-to-one relationship with the User table
        public int UserId { get; set; }
        public int CurrentLessonId { get; set; }
        public DateTime LastActivityAt { get; set; } = DateTime.UtcNow;

        public virtual User? User { get; set; }
        public virtual Lesson? CurrentLesson { get; set; }
    }
}