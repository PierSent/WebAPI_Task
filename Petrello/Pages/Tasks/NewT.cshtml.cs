using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Petrello.DataTransfer;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Petrello.Pages.Tasks
{
	public class NewTModel : PageModel
	{
		//passing two values to add the card to correct project
		public async Task<IActionResult> OnPost(TaskDto task, int id)
		{
			if (!ModelState.IsValid) return Page(); //validation of the form

			task.ProjId = id; //connecting card to project

			var taskJson = new StringContent(
				JsonSerializer.Serialize(task),
				Encoding.UTF8,
				Application.Json); // using static System.Net.Mime.MediaTypeNames;

			HttpClient client = new();
			client.BaseAddress = new Uri("https://localhost:7060"); //adress to API

			using var httpResponseMessage =
				await client.PostAsync("/api/task", taskJson);

			httpResponseMessage.EnsureSuccessStatusCode();
			return RedirectToPage("../Index");
		}





		[BindProperty]
		public TaskDto Task { get; private set; }
		public ProjectDto Project { get; set; }
	}
}
