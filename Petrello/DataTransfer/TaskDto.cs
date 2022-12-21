using System.ComponentModel.DataAnnotations;

namespace Petrello.DataTransfer
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TaskStatus Status { get; set; }
        public int Priority { get; set; } = default!;
        public int ProjId { get; set; } = default!;
    }
    public enum TaskStatus
    {
        ToDo, InProgress, Done
    }
}
