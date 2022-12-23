using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Petrello.DataTransfer;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Text.Json;

namespace Petrello.Pages.Projects
{
	public class EditPModel : PageModel
	{
		public async Task<IActionResult> OnPost(int id, ProjectDto project)
		{
			if (!ModelState.IsValid) return Page(); //validation of the form

			project.ProjectId = id;

			var projectJson = new StringContent(
				JsonSerializer.Serialize(project),
				Encoding.UTF8,
				Application.Json);

			HttpClient client = new();
			client.BaseAddress = new Uri("https://localhost:7060"); //adress to API

			using var httpResponseMessage =
				await client.PutAsync($"/api/project/{id}", projectJson);

			httpResponseMessage.EnsureSuccessStatusCode();

			return RedirectToPage("../Index");

		}

		[BindProperty]
		public ProjectDto Project { get; set; }
	}
}
