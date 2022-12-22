namespace Petrello.Extensions
{
	public static class TaskStatusExt
	{
		static readonly Dictionary<DataTransfer.TaskStatus, string> _taskStatusCssClasses = new()
		{
			[DataTransfer.TaskStatus.ToDo] = "badge rounded-pill bg-secondary",
			[DataTransfer.TaskStatus.InProgress] = "badge rounded-pill bg-primary",
			[DataTransfer.TaskStatus.Done] = "badge rounded-pill bg-success"
		};
		public static string ToCssClass(this DataTransfer.TaskStatus taskStatus) => _taskStatusCssClasses[taskStatus];

	}
}
