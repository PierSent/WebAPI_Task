using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Petrello.DataTransfer;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Petrello.Pages.Projects
{

	public class NewPModel : PageModel
	{
		public async Task<IActionResult> OnPost(ProjectDto project)
		{

			if (!ModelState.IsValid) return Page(); //validation of the form

			var projectJson = new StringContent(
				JsonSerializer.Serialize(project),
				Encoding.UTF8,
				Application.Json); // using static System.Net.Mime.MediaTypeNames;

			HttpClient client = new();
			client.BaseAddress = new Uri("https://localhost:7060"); //adress to API

			using var httpResponseMessage =
				await client.PostAsync("/api/project", projectJson);

			httpResponseMessage.EnsureSuccessStatusCode();

			return RedirectToPage("../Index");
		}


		[BindProperty]
		public ProjectDto Project { get; set; }
	}
}
