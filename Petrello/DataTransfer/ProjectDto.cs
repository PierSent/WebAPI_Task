using System.ComponentModel.DataAnnotations;

namespace Petrello.DataTransfer
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = default!;     
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
    }
    public enum ProjectStatus
    {
        NotStarted, Active, Completed
    }
}
