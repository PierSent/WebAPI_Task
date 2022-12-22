namespace Petrello.Extensions
{
	public static class ProjectStatusExt
	{
		static readonly Dictionary<DataTransfer.ProjectStatus, string> _projectStatusCssClasses = new()
		{
			[DataTransfer.ProjectStatus.NotStarted] = "badge bg-secondary",
			[DataTransfer.ProjectStatus.Active] = "badge bg-primary",
			[DataTransfer.ProjectStatus.Completed] = "badge bg-success"
		};
		public static string ToCssClass(this DataTransfer.ProjectStatus projectStatus) => _projectStatusCssClasses[projectStatus];

	}
	
}
