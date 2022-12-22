using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Text.Json;
using Petrello.DataTransfer;

namespace Petrello.Pages.Tasks
{
	public class EditTModel : PageModel
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

			httpResponseMessage.EnsureSuccessStatusCode();

			return RedirectToPage("../Index");

		}

		[BindProperty]
		public TaskDto Task { get; set; }
	}
}
