using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Petrello.DataTransfer;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Petrello.Pages.Tasks
{
	public class NewTModel : PageModel
	{
		public async Task<IActionResult> OnPost(TaskDto task)
		{

			if (!ModelState.IsValid) return Page(); //validation of the form

			var taskJson = new StringContent(
				JsonSerializer.Serialize(task),
				Encoding.UTF8,
				Application.Json); // using static System.Net.Mime.MediaTypeNames;

			HttpClient client = new();
			client.BaseAddress = new Uri("https://localhost:7060"); //adress to API

			using var httpResponseMessage =
				await client.PostAsync("/api/task", taskJson);

			HttpResponseMessage response1 = await client.GetAsync("api/project");
			response1.EnsureSuccessStatusCode();
			var projects = await response1.Content.ReadFromJsonAsync<IEnumerable<DataTransfer.ProjectDto>>();

			httpResponseMessage.EnsureSuccessStatusCode();


			//Project = await response1.Content.FindAsync;
			task.ProjId = Project.ProjectId;

			return RedirectToPage("../Index");

		}

		public void OnGetNumberId(uint id)
		{

		}



		[BindProperty]
		public TaskDto Task { get; set; }
		public ProjectDto Project { get; set; }
	}
}
