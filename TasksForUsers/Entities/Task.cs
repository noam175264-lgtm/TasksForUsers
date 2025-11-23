namespace TasksForUsers.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedToUserId { get; set; }
        public string Status { get; set; } // Pending, InProgress, Completed
        public string Priority { get; set; } // Low, Medium, High
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
