namespace TamilApp.Core.Models
{
    public class UserProgress
    {
        public long ProgressId { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public bool IsCompleted { get; set; }
        public int? Score { get; set; }
        public DateTime CompletedAt { get; set; }

        public virtual User? User { get; set; }
        public virtual Activity? Activity { get; set; }
    }
}