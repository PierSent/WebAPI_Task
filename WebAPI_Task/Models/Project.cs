using Microsoft.Build.Framework;

namespace WebAPI_Task.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; } = default!;
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
    }

    public enum ProjectStatus
    {
        NotStarted, Active, Completed
    }
}
