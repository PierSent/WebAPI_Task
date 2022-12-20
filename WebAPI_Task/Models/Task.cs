using Microsoft.Build.Framework;
using WebAPI_Task.Models;

namespace WebAPI_Task.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; } = default!;
        [Required]
        public string Description { get; set; } = default!;
        public TaskStatus Status { get; set; }
        public string Priority { get; set; } = default!;
        public int ProjectId { get; set; } = default!;
    }

    public enum TaskStatus
    {
        ToDo, InProgress, Done
    }
}
